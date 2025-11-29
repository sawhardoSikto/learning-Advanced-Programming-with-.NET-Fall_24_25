using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThirdLab.EF;

namespace ThirdLab.Controllers
{
    public class ProductController : Controller
    {
        ThirdLabEntities db = new ThirdLabEntities();
        // GET: Product
        [HttpGet]
        public ActionResult Create()
        {
            var data =   db.Catagories.ToList();

            ViewBag.Catagories = data;
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        { 
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                TempData["Msg"] ="Product Added Successfully";
                return RedirectToAction("List");
            }
            return View(product);


        }
        public ActionResult List()
        {
            var products = db.Products.ToList();
            return View(products);
        }

    }
}