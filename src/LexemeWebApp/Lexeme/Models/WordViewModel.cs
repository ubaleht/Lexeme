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
        public IEnumerable<string> WordsText { get; set; }*/
        public IEnumerable<string> SelectedWordText { get; set; }
        public IEnumerable<SelectListItem> Words { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }

        public WordViewModel()
        {
            
        }

        public void GetWordById(string strId)
        {
            int id = Convert.ToInt32(strId);
            WordDal wordDal = new WordDal();
            Start = (int)Math.Ceiling(Convert.ToDecimal(wordDal.GetWordById(id).Start/1000));
            Finish = (int)Math.Ceiling(Convert.ToDecimal(wordDal.GetWordById(id).Finish/1000 + 1));
        }
    }
}