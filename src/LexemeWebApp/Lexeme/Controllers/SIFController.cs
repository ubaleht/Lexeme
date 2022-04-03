using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lexeme.Controllers
{
    public class SIFController : Controller
    {
        // GET: SIF
        public ActionResult Index()
        {
            return RedirectPermanent("~/SiberianIngrianFinnish/Index");
        }
    }
}