using FirstLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstLab.Controllers
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
            
                List<Education> education = new List<Education>();
            var e1 = new Education()
            {
                CertificateName = "HSC",
                Year = 2021
            };
            var e2 = new Education()
            {
                CertificateName = "SSC",
                Year = 2019
            };
            education.Add(e1);
            education.Add(e2);

            return View(education);
                
        }
        public ActionResult Projects()
        {
            
                List<Project> project = new List<Project>();
                for (int i = 1; i <= 20; i++)
                {
                    project.Add(new Project()
                    {
                        Title = i,
                        Name = "P" + i,
                        Description = "abc" + i,
                    });
                }

                return View(project);
                
        }
        public ActionResult Reference()
        {
            return View();
        }
    }
}