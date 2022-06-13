using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class FragmentSty : Fragment
    {
        public List<SpeakerSpeechSty> SpeakerSpeechListSty { get; set; }
        public List<InterviewerSpeechSty> InterviewerSpeechListSty { get; set; }

        public FragmentSty() : base() { }
    }
}
