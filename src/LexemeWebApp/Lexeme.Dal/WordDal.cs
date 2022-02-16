using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Lexeme.Dal
{
    public class WordDal
    {
        private string connectionString = System.Configuration.ConfigurationSettings.AppSettings["DBConnection"].Replace("\\\\", "\\");

        public WordDal() { }

        public Word GetWordById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
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
                            WordComments = reader.GetString(reader.GetOrdinal("WordComments"))
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
                                    WordText = reader.GetString(reader.GetOrdinal("Word")),
                                    WordEnTranslation = reader.GetString(reader.GetOrdinal("WordEnTranslation")),
                                    WordRuTranslation = reader.GetString(reader.GetOrdinal("WordRuTranslation")),
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
    }
}
