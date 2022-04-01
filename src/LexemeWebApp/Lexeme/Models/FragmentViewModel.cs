using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lexeme.Dal;

namespace Lexeme.Models
{
    public class FragmentViewModel
    {
        public int Start { get; set; }
        public int Finish { get; set; }
        public string SpeakerSpeechesByFragment { get; set; }
        public string InterviewerSpeechesByFragment { get; set; }
        public string FileName { get; set;}

        public FragmentViewModel() { }

        public void GetFragmentByWordId(string wordIdStr)
        {
            int wordId = Convert.ToInt32(wordIdStr);

            FragmentDal fragmentDal = new FragmentDal();

            Fragment fragment = fragmentDal.GetFragmentByWordId(wordId);

            Start = fragment.Start;
            Finish = fragment.Finish;
            FileName = fragment.FileName;
            SpeakerSpeechesByFragment = (fragment.SpeakerSpeechList.Count > 0) ? string.Join(". ", fragment.SpeakerSpeechList.Select(x => x.SpeakerSpeechText)) : String.Empty;
            InterviewerSpeechesByFragment = (fragment.InterviewerSpeechList.Count > 0) ? string.Join(". ", fragment.InterviewerSpeechList.Select(x => x.InterviewerSpeechText)) : String.Empty;
        }
    }
}