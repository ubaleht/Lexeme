using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lexeme.Dal
{
    public class WordDal
    {
        private string connectionString = System.Configuration.ConfigurationSettings.AppSettings["DBConnection"].Replace("\\\\", "\\");

        public WordDal() { }

        public Word GetWordById(int id)
        {
            string speakerCode = string.Empty;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "select SpeakerPersonalCode from SpeakerSpeech, Word where Word.IdSpeakerSpeech = SpeakerSpeech.Id and Word.Id = @id2";
                    cmd.Parameters.AddWithValue("@id2", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        speakerCode = reader.GetString(reader.GetOrdinal("SpeakerPersonalCode"));
                        
                    }

                    cmd.CommandText = "SELECT Id, IdSpeakerSpeech, Start, Finish, Word, WordEnTranslation, WordRuTranslation, PartOfSpeech, WordComments FROM Word WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        return new Word
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            IdSpeakerSpeech = reader.GetInt32(reader.GetOrdinal("IdSpeakerSpeech")),
                            Start = reader.GetInt32(reader.GetOrdinal("Start")),
                            Finish = reader.GetInt32(reader.GetOrdinal("Finish")),
                            WordText = reader.GetString(reader.GetOrdinal("Word")),
                            WordEnTranslation = reader.GetString(reader.GetOrdinal("WordEnTranslation")),
                            WordRuTranslation = reader.GetString(reader.GetOrdinal("WordRuTranslation")),
                            PartOfSpeech = reader.GetString(reader.GetOrdinal("PartOfSpeech")),
                            WordComments = reader.GetString(reader.GetOrdinal("WordComments")),
                            SpeakerCode = speakerCode
                        };
                    }
                }
            }
        }

        public List<Word> GetWordList()
        {
            List<Word> wordList = new List<Word>();

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT Id, IdSpeakerSpeech, Start, Finish, Word, WordEnTranslation, WordRuTranslation, PartOfSpeech, WordComments FROM Word";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wordList.Add(
                                new Word()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    IdSpeakerSpeech = reader.GetInt32(reader.GetOrdinal("IdSpeakerSpeech")),
                                    Start = reader.GetInt32(reader.GetOrdinal("Start")),
                                    Finish = reader.GetInt32(reader.GetOrdinal("Finish")),
                                    WordText = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("Word"))),
                                    WordEnTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("WordEnTranslation"))),
                                    WordRuTranslation = FirstLatterToUppercase(reader.GetString(reader.GetOrdinal("WordRuTranslation"))),
                                    PartOfSpeech = reader.GetString(reader.GetOrdinal("PartOfSpeech")),
                                    WordComments = reader.GetString(reader.GetOrdinal("WordComments"))
                                }
                            );
                        }
                    }
                }
            }
            return wordList;
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
