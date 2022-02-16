using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lexeme.Models;
using Lexeme.Dal;

namespace Lexeme.Controllers
{
    public class SiberianIngrianFinnishController : Controller
    {
        // GET: SiberianIngrianFinnish
        /*public ActionResult Index()
        {
            WordViewModel wordViewModel = new WordViewModel();

            return View(wordViewModel);
        }*/

        [HttpGet]
        public ActionResult Index()
        {
            WordViewModel wordViewModel = new WordViewModel();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();
            List<Word> words = new WordDal().GetWordList();

            /*if (wordViewModel.SelectedWordText != null)
            {
                List<SelectListItem> selectedItems = wordViewModel.SelectedWordText;
                foreach (var Tea in selectedItems)
                {
                    Tea.Selected = true;
                    ViewBag.Message += Tea.Text + " | ";
                }
            }*/

            foreach (Word word in words)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = word.WordText,
                    Value = word.Id.ToString(),
                    Selected = true
                };
                listSelectListItems.Add(selectList);
            }

            wordViewModel.Words = listSelectListItems;

            return View(wordViewModel);
        }

        [HttpPost]
        public string Index(IEnumerable<string> selectedWordText)
        {
            if (selectedWordText == null)
            {
                return "No cities are selected";
            }
            else
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("You selected – " + string.Join(",", selectedCities));
                return selectedWordText.SingleOrDefault();
            }
        }


        }
}