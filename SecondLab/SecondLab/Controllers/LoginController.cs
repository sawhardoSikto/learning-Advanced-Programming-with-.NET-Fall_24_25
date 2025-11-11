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
        public ActionResult Login()
        {
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
                ViewBag.Message = "Registration Successful";
                
            }
            return View(r);
        }

    }
}