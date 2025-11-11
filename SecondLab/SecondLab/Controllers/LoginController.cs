using SecondLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondLab.Controllers
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
            return View(new Login());
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Login Successful";
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
            if (ModelState.IsValid)
            {
                TempData["Msg"] = "Registration Successfull";
                return RedirectToAction("Login");


            }
            return View(r);
        }

    }
}