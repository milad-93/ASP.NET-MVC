using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebbsidaExam.Controllers
{
    public class AdminController : Controller
    {
        private LagradeBilarEntities db = new LagradeBilarEntities();

       
       [Authorize] // sidan nås endast! vid inloggning
        public ActionResult VisaUppLagradBil()
        {
            // viewen leder till tabellen checkainBil i databasen som har modellnamnet bilmodell
            return View(db.CheckaInBil.ToList());
        }



        public ActionResult Register()  //GET
        {
            return View();
        }

        [HttpPost] //set
        public ActionResult Register(User newUser) // REGISTRERAR ETT KONTO PÅ SIDAN 
        {
            db.User.Add(newUser); //´lägger in ny användare i databasen
            db.SaveChanges();  //sparar databasen

            return RedirectToAction("Index", "Home"); // skickas till main när jag e klar
        }


        public ActionResult Login() //get
        {
            return View();
        }
       
        [HttpPost] //SET
        public ActionResult Login(Models.User inloggning) //logga in funktion
        {
            if(inloggning.Username == null || inloggning.Password == null)
            {
                ModelState.AddModelError("", "Du måste fylla i båda fälten");

                return View();
            }


            bool validUser = false; // kontrollerar
            //validUser = System.Web.Security.FormsAuthentication.Authenticate(inloggning.Username, inloggning.Password);
            validUser = CheckUser(inloggning.Username, inloggning.Password); // alltså min funktion längre nere "checkUser" 

            if (validUser == true)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(inloggning.Username, false); // om användaren är godkänd
            }

            ModelState.AddModelError("", "Inlogg felaktig");

            return View();
           
        }


        private bool CheckUser(string username, string password) //checkar databasen att rätt användare finns
        {
            var anvandare = from rader in db.User
                            where rader.Username.ToUpper() == username.ToUpper()
                            && rader.Password == password
                            select rader;


            if (anvandare.Count() == 1)
            {
                return true;
            }

            else
            {
                return false;
            }


        }


        public ActionResult Logout() //logga ut funktion behövs ingen vy för denna funktion
        {
            System.Web.Security.FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}