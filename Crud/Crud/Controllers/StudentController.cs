using Crud.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class StudentController : Controller
    {
        MyDBEntities db = new MyDBEntities();
        // GET: Student

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(s);
        }
        public ActionResult List()
        {
           
           
         


            // Return full student list to the view
            var data = db.Students.ToList();

            return View(data);
        }
        
    }
}