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
        public string SpeakerMorph { get; set; }
        public string SpeakerComments { get; set; }

        public WordViewModel()
        {
            
        }

        public void GetWordById(string strId)
        {
            int id = Convert.ToInt32(strId);
            WordDal wordDal = new WordDal();
            WordsText = wordDal.GetWordById(id).WordText;
            Start = (wordDal.GetWordById(id).Start % 1000 <= 850)? wordDal.GetWordById(id).Start / 1000 : (wordDal.GetWordById(id).Start / 1000) + 1;
            Finish = (wordDal.GetWordById(id).Finish % 1000 >= 150)? (wordDal.GetWordById(id).Finish / 1000) + 1 : wordDal.GetWordById(id).Finish / 1000;
            SpeakerEnTranslate = wordDal.GetWordById(id).WordEnTranslation;
            SpeakerRuTranslate = wordDal.GetWordById(id).WordRuTranslation;
            SpeakerMorph = (wordDal.GetWordById(id).PartOfSpeech != String.Empty)? wordDal.GetWordById(id).PartOfSpeech : "None";
            SpeakerComments = (wordDal.GetWordById(id).WordComments != String.Empty) ? wordDal.GetWordById(id).WordComments : "None";
        }
    }
}