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
        public WordViewModel wordViewModel;
        public List<SelectListItem> listSelectListItems;

        public SiberianIngrianFinnishController()
        {
            wordViewModel = new WordViewModel();
            listSelectListItems = new List<SelectListItem>();
            List<Word> words = new WordDal().GetWordList();

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
        }

        // GET: SiberianIngrianFinnish
        /*public ActionResult Index()
        {
            WordViewModel wordViewModel = new WordViewModel();

            return View(wordViewModel);
        }*/

        [HttpGet]
        public ActionResult Index()
        {
            

            /*if (wordViewModel.SelectedWordText != null)
            {
                List<SelectListItem> selectedItems = wordViewModel.SelectedWordText;
                foreach (var Tea in selectedItems)
                {
                    Tea.Selected = true;
                    ViewBag.Message += Tea.Text + " | ";
                }
            }*/

            

            return View(wordViewModel);
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<string> selectedWordText)
        {
            //wordViewModel.Words = listSelectListItems;
            if (selectedWordText == null)
            {
                ViewBag.Message = "No cities are selected";
            }
            else
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("You selected – " + string.Join(",", selectedCities));
                ViewBag.Message = selectedWordText.SingleOrDefault();
            }

            return View(wordViewModel);
        }
    }
}