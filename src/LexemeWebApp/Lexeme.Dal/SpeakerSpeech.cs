using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class SpeakerSpeech
    {
        public int Id { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public string SpeakerSpeechText { get; set; }
        public string SpeakerSpeechEnTranslation { get; set; }
        public string SpeakerSpeechRuTranslation { get; set; }


        public SpeakerSpeech()
        { }
    }
}
