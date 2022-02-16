using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class Word
    {
        public int Id { get; set; }
        public int IdSpeakerSpeech { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public string WordText { get; set; }
        public string WordEnTranslation { get; set; }
        public string WordRuTranslation { get; set; }
        public string PartOfSpeech { get; set; }
        public string WordComments { get; set; }
        public Word() { }
    }
}
