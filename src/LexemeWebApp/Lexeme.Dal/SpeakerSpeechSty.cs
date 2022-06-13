using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class SpeakerSpeechSty : SpeakerSpeech
    {
        public string SpeakerSpeechTrTranslation { get; set; }
        public string SpeakerSpeechLatin { get; set; }

        public SpeakerSpeechSty() : base() { }
    }
}
