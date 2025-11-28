using mid1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace mid1.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Education()
        {
            List<Education> edu = new List<Education>();
            var e1 = new Education()
            {
                CertificateName = "Bachelor of Science in Computer Science",
                Institution = "State University",
                YearOfCompletion = 2026
            };
            var e2 = new Education()
            {
                CertificateName = "HSC",
                Institution = "Cambrian College",
                YearOfCompletion = 2021
            };
            edu.Add(e1);
            edu.Add(e2);

            return View(edu);
        }

        public ActionResult Project()
        {
            List<Project> projects = new List<Project>();
            var p1 = new Project()
            {
                Title = 1,
                Name = "Personal Portfolio Website",
                Description = "A personal website to showcase my projects and skills."
            };
            var p2 = new Project()
            {
                Title = 2,
                Name = "E-commerce Platform",
                Description = "An online platform for buying and selling products."
            };

            projects.Add(p1);
            projects.Add(p2);


            return View(projects);
        }

        public ActionResult Reference()
        {
            ViewBag.Message = "Your reference page.";
            return View();
        }
    }
}