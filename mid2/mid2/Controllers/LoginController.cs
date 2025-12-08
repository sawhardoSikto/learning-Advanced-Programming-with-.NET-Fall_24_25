using mid2.EF;
using mid2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace mid2.Controllers
{
    public class LoginController : Controller
    {
        ThirdLabEntities db = new ThirdLabEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            
            return View(new Login());

        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                // Database theke email & password match
                var user = (from u in db.Users
                            where u.StudentId == login.Id && u.Password == login.Password
                            select u).FirstOrDefault();

                if (user != null)
                {
                    TempData["msg"] = "Login Successful";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.Error = "Invalid Email or Password";
                }
            }

            return View(login);
        }








        [HttpGet]
        public ActionResult Registration()
        {

            return View(new Registration());
        }
        [HttpPost]
        public ActionResult Registration(Registration r)
        {
            if(ModelState.IsValid)
            {
                User u = new User();
                u.Name = r.Name;
                u.Password = r.Password;
                u.StudentId = r.Id;
                u.Email = r.Email;
                u.Profession = r.Profession;
                u.Gender = r.Gender;
                u.Hobbies = string.Join(",", r.Hobbies);
                db.Users.Add(u);
                db.SaveChanges();
                
                TempData["msg"] = "Registration Successful";
                return RedirectToAction("Login");
            }
            return View(r);
        }
    }
}