using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class InterviewerSpeech
    {
        public int Id { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public string InterviewerSpeechText { get; set; }
        public string InterviewerSpeechEnTranslation { get; set; }

        public InterviewerSpeech()
        { }
    }
}
