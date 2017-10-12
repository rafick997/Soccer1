using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Football.Models;
using System.Web.Security;

namespace Football.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                User user = null;
                using (SoccerEntities db = new SoccerEntities())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name);
                }
                if (user == null)
                {
                    using (SoccerEntities db = new SoccerEntities())
                    {
                        db.Users.Add(new User { Email = model.Name, Password = model.Password, Age = model.Age, RoleId=2 });
                        db.SaveChanges();
                        user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();

                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Team1");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Uzytkownik z takim loginem juz istnieje");
                }

            }
            return View(model);
     
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Team1");
        }

        public ActionResult Login()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (SoccerEntities db = new SoccerEntities())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name);
                }
             
                   
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Team1");
                    }
                
                else
                {
                    ModelState.AddModelError("", "Brak uzytkownika z takimi danymi");
                }

            }
            return View(model);

        }

    }
}