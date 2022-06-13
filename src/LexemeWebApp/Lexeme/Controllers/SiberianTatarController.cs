using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lexeme.Models;
using Lexeme.Dal;

namespace Lexeme.Controllers
{
    public class SiberianTatarController : Controller
    {
        public WordViewModel wordViewModel;
        public List<SelectListItem> listSelectListItems;

        public FragmentViewModel fragmentViewModel;

        public SiberianTatarController()
        {
            wordViewModel = new WordViewModel();
            listSelectListItems = new List<SelectListItem>();
            List<WordSty> words = new WordDal().GetWordListSty();

            foreach (Word word in words)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = word.WordText,
                    Value = word.Id.ToString(),
                    Selected = false
                };
                listSelectListItems.Add(selectList);
            }

            wordViewModel.Words = listSelectListItems;

            fragmentViewModel = new FragmentViewModel();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(wordViewModel);
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<string> selectedWordText)
        {
            //wordViewModel.Words = listSelectListItems;
            if (selectedWordText == null)
            {
                ViewBag.Message = "No words are selected";
            }
            else
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("You selected – " + string.Join(",", selectedCities));
                ViewBag.Message = selectedWordText.ToArray()[0];
            }

            return View(wordViewModel);
        }

        [HttpGet]
        public ActionResult Context(string word)
        {
            ViewBag.Message = word;

            return View(fragmentViewModel);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}