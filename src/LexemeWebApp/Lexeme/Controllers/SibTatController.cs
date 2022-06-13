using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lexeme.Controllers
{
    public class SibTatController : Controller
    {
        // GET: SibTat
        public ActionResult Index()
        {
            return RedirectPermanent("~/SiberianTatar/Index");
        }
    }
}