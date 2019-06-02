using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbsidaExam.Controllers
{
    public class BilarLagradeController : Controller
    {
        //skapar objekt av min databas 
        private LagradeBilarEntities db = new LagradeBilarEntities();

       //get
        public ActionResult LagraBil()
        {


            return View();

        }

        [HttpPost]    //set
        public ActionResult LagraBil(CheckaInBil nyBil)
        {
            db.CheckaInBil.Add(nyBil); //´lägger in bilen i databas
            db.SaveChanges();  //sparar databasen

            return RedirectToAction("Index", "Home"); // gå till main

        }





    }
}