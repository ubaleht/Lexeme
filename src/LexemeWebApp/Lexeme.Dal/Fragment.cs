using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class Fragment
    {
        public int Id { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public string FragmentName { get; set; }
        public List<SpeakerSpeech> SpeakerSpeechList { get; set; }
        public List<InterviewerSpeech> InterviewerSpeechList { get; set; }
        public string FileName { get; set; }

        public Fragment() { }
    }
}
