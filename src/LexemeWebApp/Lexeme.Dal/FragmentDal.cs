using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lexeme.Dal
{
    public class FragmentDal
    {
        private string connectionString = System.Configuration.ConfigurationSettings.AppSettings["DBConnection"].Replace("\\\\", "\\");

        private int generalFragmentId = 0;
        private int generalFragmentStart = 0;
        private int generalFragmentFinish = 0;
        private List<SpeakerSpeech> speakerSpeechList = new List<SpeakerSpeech>();
        private List<InterviewerSpeech> interviewerSpeechList = new List<InterviewerSpeech>();

        public FragmentDal() { }

        public Fragment GetFragmentByWordId(int wordId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "select GeneralFragment.Id, GeneralFragment.Start, GeneralFragment.Finish from GeneralFragment, SpeakerSpeech, Word " +
                                      "where Word.Id = @wordId and Word.IdSpeakerSpeech = SpeakerSpeech.Id and GeneralFragment.Id = SpeakerSpeech.IdGeneralFragment";
                    cmd.Parameters.AddWithValue("@wordId", wordId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        generalFragmentId = reader.GetInt32(reader.GetOrdinal("GeneralFragment.Id"));
                        generalFragmentStart = reader.GetInt32(reader.GetOrdinal("GeneralFragment.Start"));
                        generalFragmentFinish = reader.GetInt32(reader.GetOrdinal("GeneralFragment.Finish"));
                    }

                    cmd.CommandText = "select SpeakerSpeech.Speech, SpeakerSpeech.SpeechEnTranslation, SpeakerSpeech.SpeechRuTranslation from SpeakerSpeech join GeneralFragment on GeneralFragment.Id = SpeakerSpeech.IdGeneralFragment where GeneralFragment.Id = @generalFragmentId";
                    cmd.Parameters.AddWithValue("@generalFragmentId", generalFragmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            speakerSpeechList.Add(
                                new SpeakerSpeech()
                                {
                                    SpeakerSpeechText = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeakerSpeech.Speech"))),
                                    SpeakerSpeechEnTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeakerSpeech.SpeechEnTranslation"))),
                                    SpeakerSpeechRuTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeakerSpeech.SpeechRuTranslation")))
                                }
                            );
                        }
                    }

                    cmd.CommandText = "select InterviewerSpeech.InterviewerSpeech, InterviewerSpeech.InterviewerSpeechEnTranslation from InterviewerSpeech join GeneralFragment on GeneralFragment.Id = InterviewerSpeech.IdGeneralFragment where GeneralFragment.Id = @generalFragmentId2";
                    cmd.Parameters.AddWithValue("@generalFragmentId2", generalFragmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            interviewerSpeechList.Add(
                                new InterviewerSpeech()
                                {
                                    InterviewerSpeechText = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("InterviewerSpeech.InterviewerSpeech"))),
                                    InterviewerSpeechEnTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeakerSpeech.SpeechEnTranslation")))
                                }
                            );
                        }
                    }
                }
            }

            return new Fragment()
            {
                Start = generalFragmentStart,
                Finish = generalFragmentFinish,
                SpeakerSpeechList = speakerSpeechList,
                InterviewerSpeechList = interviewerSpeechList
            };
            
        }

        //TODO: Move to helper class
        private string FirstLatterToUppercase(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
