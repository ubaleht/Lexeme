using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class WordSty : Word
    {
        public string WordTrTranslation { get; set; }
        public string WordLatin { get; set; }

        public WordSty() : base() { }

    }
}
