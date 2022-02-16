using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lexeme.Models
{
    public class WordViewModel
    {
        /*public Word SelectedWord { get; set; }
        public IEnumerable<Word> Words { get; set; }
        public IEnumerable<string> WordsText { get; set; }*/
        public IEnumerable<string> SelectedWordText { get; set; }
        public IEnumerable<SelectListItem> Words { get; set; }

        public WordViewModel()
        {
            
        }
    }
}