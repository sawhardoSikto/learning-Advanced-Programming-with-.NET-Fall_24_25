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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            Student student = new Student()
            {
                Name = "John Doe",
                Gender = "male",
                Email = "siktobiswas@gmail.com "
            };
            db.Students.Add(student);
            db.SaveChanges();

            // Return full student list to the view
            var data = db.Students.ToList();

            return View(data);
        }
    }
}