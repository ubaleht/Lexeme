using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lexeme.Dal;

namespace Lexeme.Models
{
    public class FragmentViewModel
    {
        public int Start { get; set; }
        public int Finish { get; set; }
        public string SpeakerSpeechAllInFragment { get; set; }
        public string InterviwerSpeechAllInFragment { get; set; }

        public void GetFragmentByWordId(int wordId)
        {
            FragmentDal fragmentDal = new FragmentDal();

            Fragment fragment = fragmentDal.GetFragmentByWordId(wordId);

            Start = fragment.Start;
            Finish = fragment.Finish;
            SpeakerSpeechAllInFragment = (fragment.SpeakerSpeechList.Count > 0) ? string.Join(". ", fragment.SpeakerSpeechList.Select(x => x.SpeakerSpeechText)) : String.Empty;
            //TODO: InterviwerSpeechAllInFragment
        }
    }
}