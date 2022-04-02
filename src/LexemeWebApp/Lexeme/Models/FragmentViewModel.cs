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
        public string SpeakerSpeechesByFragmentEnTranslation { get; set; }
        public string SpeakerSpeechesByFragmentRuTranslation { get; set; }
        public string InterviewerSpeechesByFragment { get; set; }
        public string InterviewerSpeechesByFragmentEnTranslation { get; set; }
        public string FileName { get; set;}

        public FragmentViewModel() { }

        public void GetFragmentByWordId(string wordIdStr)
        {
            int wordId = Convert.ToInt32(wordIdStr);

            FragmentDal fragmentDal = new FragmentDal();

            Fragment fragment = fragmentDal.GetFragmentByWordId(wordId);

            Start = (fragment.Start % 1000 <= 850) ? fragment.Start / 1000 : (fragment.Start / 1000) + 1;
            Finish = (fragment.Finish % 1000 >= 150) ? (fragment.Finish / 1000) + 1 : fragment.Finish / 1000;
            FileName = fragment.FileName + ".WAV";
            SpeakerSpeechesByFragment = (fragment.SpeakerSpeechList.Count > 0) ? string.Join(". ", fragment.SpeakerSpeechList.Select(x => x.SpeakerSpeechText)) : String.Empty;
            SpeakerSpeechesByFragmentEnTranslation = (fragment.SpeakerSpeechList.Count > 0) ? string.Join(". ", fragment.SpeakerSpeechList.Select(x => x.SpeakerSpeechEnTranslation)) : String.Empty;
            SpeakerSpeechesByFragmentRuTranslation = (fragment.SpeakerSpeechList.Count > 0) ? string.Join(". ", fragment.SpeakerSpeechList.Select(x => x.SpeakerSpeechRuTranslation)) : String.Empty;
            InterviewerSpeechesByFragment = (fragment.InterviewerSpeechList.Count > 0) ? string.Join(". ", fragment.InterviewerSpeechList.Select(x => x.InterviewerSpeechText)) : String.Empty;
            InterviewerSpeechesByFragmentEnTranslation = (fragment.InterviewerSpeechList.Count > 0) ? string.Join(". ", fragment.InterviewerSpeechList.Select(x => x.InterviewerSpeechEnTranslation)) : String.Empty;
        }
    }
}