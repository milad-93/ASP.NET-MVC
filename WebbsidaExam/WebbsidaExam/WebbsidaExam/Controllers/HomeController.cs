using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbsidaExam.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.welcome = "Välkommen till Milads bilverkstad";


            return View();
        }
    }
}