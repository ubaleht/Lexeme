using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lexeme.Dal;

namespace Lexeme.Models
{
    public class WordViewModel
    {
        /*public Word SelectedWord { get; set; }
        public IEnumerable<Word> Words { get; set; }
        */
        public IEnumerable<string> SelectedWordText { get; set; }
        public IEnumerable<SelectListItem> Words { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public string WordsText { get; set; }
        public string SpeakerEnTranslate { get; set; }
        public string SpeakerRuTranslate { get; set; }
        public string SpeakerTrTranslate { get; set; }
        public string SpeakerWordTextLatin { get; set; }
        public string SpeakerMorph { get; set; }
        public string SpeakerComments { get; set; }
        public string SpeakerCode { get; set; }
        public string AudioFileName { get; set; }
        public string SpeakerPersonalInfo { get; set; }
        public string RecContext { get; set; }

        public WordViewModel()
        {
            
        }

        public void GetWordById(string strId)
        {
            int id = Convert.ToInt32(strId);
            WordDal wordDal = new WordDal();
            Word word = wordDal.GetWordById(id);
            WordsText = word.WordText;
            Start = (word.Start % 1000 <= 850)? word.Start / 1000 : (word.Start / 1000) + 1;
            Finish = (word.Finish % 1000 >= 150)? (word.Finish / 1000) + 1 : word.Finish / 1000;
            SpeakerEnTranslate = word.WordEnTranslation;
            SpeakerRuTranslate = word.WordRuTranslation;
            SpeakerMorph = (word.PartOfSpeech != String.Empty)? word.PartOfSpeech : "None";
            SpeakerComments = (word.WordComments != String.Empty) ? word.WordComments : "None";
            SpeakerCode = word.SpeakerCode;
            AudioFileName = GetAudioFileName(SpeakerCode);
            SpeakerPersonalInfo = GetSpeakerPersonalInfo(SpeakerCode);
            RecContext = GetRecContext(SpeakerCode);
        }

        public void GetWordByIdSty(string strId)
        {
            int id = Convert.ToInt32(strId);
            WordDal wordDal = new WordDal();
            WordSty word = wordDal.GetWordByIdSty(id);
            WordsText = word.WordText;
            Start = (word.Start % 1000 <= 850) ? word.Start / 1000 : (word.Start / 1000) + 1;
            Finish = (word.Finish % 1000 >= 150) ? (word.Finish / 1000) + 1 : word.Finish / 1000;
            SpeakerEnTranslate = word.WordEnTranslation;
            SpeakerRuTranslate = word.WordRuTranslation;
            SpeakerTrTranslate = (word.WordTrTranslation != String.Empty) ? word.WordTrTranslation : "None";
            SpeakerWordTextLatin = (word.WordLatin != String.Empty) ? word.WordLatin : "None";
            SpeakerMorph = (word.PartOfSpeech != String.Empty) ? word.PartOfSpeech : "None";
            SpeakerComments = (word.WordComments != String.Empty) ? word.WordComments : "None";
            SpeakerCode = word.SpeakerCode;
            AudioFileName = GetAudioFileName(SpeakerCode);
            SpeakerPersonalInfo = GetSpeakerPersonalInfo(SpeakerCode);
            RecContext = GetRecContext(SpeakerCode);
        }

        //TODO: Get this information from DB
        private string GetAudioFileName(string speakerCode)
        {
            if (speakerCode == "KKM-34")
                return "KKM-34-003.WAV";
            else if (speakerCode == "MAP-49")
                return "MAP-49-002.WAV";
            else if (speakerCode == "MMM-39")
                return "MMM-39_2019-05-26_02.WAV";
            else if (speakerCode == "AAK-47")
                return "AAK-47-001.WAV";
            else if (speakerCode == "NGA-45")
                return "NGA-45_2021-07-22_03.WAV";
            else return string.Empty;
        }

        //TODO: Get this information from DB
        private string GetSpeakerPersonalInfo(string speakerCode)
        {
            if (speakerCode == "KKM-34")
                return "Code: KKM-34, Year of birth: 1934, Male, Current place of residence: Ryzhkovo, Place of the birth: Ryzhkovo, Birthplace of parents: both parents Ryzhkovo";
            else if (speakerCode == "MAP-49")
                return "Code: MAP-49, Year of birth: 1949, Female, Current place of residence: Ryzhkovo, Place of the birth: Ryzhkovo, Birthplace of parents: both parents Ryzhkovo";
            else if (speakerCode == "MMM-39")
                return "Code: MMM-39, Year of birth: 1939, Male, Current place of residence: Ryzhkovo, Place of the birth: Ryzhkovo, Birthplace of parents: both parents Ryzhkovo";
            else if (speakerCode == "AAK-47")
                return "Code: AAK-47, Year of birth: 1947, Male, Current place of residence: Ryzhkovo, Place of the birth: Säde, Birthplace of parents: mother: Ryzhkovo, father: no data";
            else if (speakerCode == "NGA-45")
                return "Code: NGA-45, Year of birth: 1945, Female, Current place of residence: Ilchebaga, Place of the birth: Yarkovo.";
            else return string.Empty;
        }

        //TODO: Get this information from DB
        private string GetRecContext(string speakerCode)
        {
            if (speakerCode == "KKM-34")
                return "Ryzhkovo, 23.06.2019";
            else if (speakerCode == "MAP-49")
                return "Ryzhkovo, 26.05.2019";
            else if (speakerCode == "MMM-39")
                return "Ryzhkovo, 26.05.2019";
            else if (speakerCode == "AAK-47")
                return "Krutinka, 15.09.2019";
            else if (speakerCode == "NGA-45")
                return "Ilchebaga, 22.07.2021";
            else return string.Empty;
        }
    }
}