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

        private string connectionString2 = System.Configuration.ConfigurationSettings.AppSettings["DBConnection2"].Replace("\\\\", "\\");

        private int generalFragmentId = 0;
        private int generalFragmentStart = 0;
        private int generalFragmentFinish = 0;
        private string generalFragmentFileName = string.Empty;

        private List<SpeakerSpeech> speakerSpeechList = new List<SpeakerSpeech>();
        private List<InterviewerSpeech> interviewerSpeechList = new List<InterviewerSpeech>();

        private List<SpeakerSpeechSty> speakerSpeechListSty = new List<SpeakerSpeechSty>();
        private List<InterviewerSpeechSty> interviewerSpeechListSty = new List<InterviewerSpeechSty>();

        public FragmentDal() { }

        public Fragment GetFragmentByWordId(int wordId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "select GeneralFragment.Id, GeneralFragment.Start, GeneralFragment.Finish, GeneralFragment.FileNameFieldWorkFile from GeneralFragment, SpeakerSpeech, Word " +
                                      "where Word.Id = @wordId and Word.IdSpeakerSpeech = SpeakerSpeech.Id and GeneralFragment.Id = SpeakerSpeech.IdGeneralFragment";
                    cmd.Parameters.AddWithValue("@wordId", wordId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        generalFragmentId = reader.GetInt32(0);
                        generalFragmentStart = reader.GetInt32(1);
                        generalFragmentFinish = reader.GetInt32(2);
                        generalFragmentFileName = reader.GetString(3);
                    }

                    cmd.CommandText = "select Speech, SpeechEnTranslation, SpeechRuTranslation from SpeakerSpeech join GeneralFragment on GeneralFragment.Id = SpeakerSpeech.IdGeneralFragment where GeneralFragment.Id = @generalFragmentId";
                    cmd.Parameters.AddWithValue("@generalFragmentId", generalFragmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            speakerSpeechList.Add(
                                new SpeakerSpeech()
                                {
                                    SpeakerSpeechText = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("Speech"))),
                                    SpeakerSpeechEnTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeechEnTranslation"))),
                                    SpeakerSpeechRuTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeechRuTranslation")))
                                }
                            );
                        }
                    }

                    cmd.CommandText = "select InterviewerSpeech, InterviewerSpeechEnTranslation from InterviewerSpeech join GeneralFragment on GeneralFragment.Id = InterviewerSpeech.IdGeneralFragment where GeneralFragment.Id = @generalFragmentId2";
                    cmd.Parameters.AddWithValue("@generalFragmentId2", generalFragmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            interviewerSpeechList.Add(
                                new InterviewerSpeech()
                                {
                                    InterviewerSpeechText = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("InterviewerSpeech"))),
                                    InterviewerSpeechEnTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("InterviewerSpeechEnTranslation")))
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
                InterviewerSpeechList = interviewerSpeechList,
                FileName = generalFragmentFileName
            };
            
        }

        public FragmentSty GetFragmentByWordIdSty(int wordId)
        {
            using (var conn = new SqlConnection(connectionString2))
            {

                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "select GeneralFragment.Id, GeneralFragment.Start, GeneralFragment.Finish, GeneralFragment.FileNameFieldWorkFile from GeneralFragment, SpeakerSpeech, Word " +
                                      "where Word.Id = @wordId and Word.IdSpeakerSpeech = SpeakerSpeech.Id and GeneralFragment.Id = SpeakerSpeech.IdGeneralFragment";
                    cmd.Parameters.AddWithValue("@wordId", wordId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        generalFragmentId = reader.GetInt32(0);
                        generalFragmentStart = reader.GetInt32(1);
                        generalFragmentFinish = reader.GetInt32(2);
                        generalFragmentFileName = reader.GetString(3);
                    }

                    cmd.CommandText = "select Speech, SpeechEnTranslation, SpeechRuTranslation, SpeechTrTranslation, SpeechLatin from SpeakerSpeech join GeneralFragment on GeneralFragment.Id = SpeakerSpeech.IdGeneralFragment where GeneralFragment.Id = @generalFragmentId";
                    cmd.Parameters.AddWithValue("@generalFragmentId", generalFragmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            speakerSpeechListSty.Add(
                                new SpeakerSpeechSty()
                                {
                                    SpeakerSpeechText = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("Speech"))),
                                    SpeakerSpeechEnTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeechEnTranslation"))),
                                    SpeakerSpeechRuTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeechRuTranslation"))),
                                    SpeakerSpeechTrTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeechTrTranslation"))),
                                    SpeakerSpeechLatin = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("SpeechLatin")))
                                }
                            );
                        }
                    }

                    cmd.CommandText = "select InterviewerSpeech, InterviewerSpeechEnTranslation, InterviewerSpeechTrTranslation from InterviewerSpeech join GeneralFragment on GeneralFragment.Id = InterviewerSpeech.IdGeneralFragment where GeneralFragment.Id = @generalFragmentId2";
                    cmd.Parameters.AddWithValue("@generalFragmentId2", generalFragmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            interviewerSpeechListSty.Add(
                                new InterviewerSpeechSty()
                                {
                                    InterviewerSpeechText = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("InterviewerSpeech"))),
                                    InterviewerSpeechEnTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("InterviewerSpeechEnTranslation"))),
                                    InterviewerSpeechTrTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("InterviewerSpeechTrTranslation")))
                                }
                            );
                        }
                    }
                }
            }

            return new FragmentSty()
            {
                Start = generalFragmentStart,
                Finish = generalFragmentFinish,
                SpeakerSpeechListSty = speakerSpeechListSty,
                InterviewerSpeechListSty = interviewerSpeechListSty,
                FileName = generalFragmentFileName
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
