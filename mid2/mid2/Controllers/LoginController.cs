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
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {

                TempData["msg"] = "Login Successful";
                return RedirectToAction("Index", "Home");
            }
            return View();
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
                TempData["msg"] = "Registration Successful";
                return RedirectToAction("Login");
            }
            return View(r);
        }
    }
}