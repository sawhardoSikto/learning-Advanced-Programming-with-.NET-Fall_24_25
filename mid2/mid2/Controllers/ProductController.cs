using mid2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mid2.Controllers
{
    public class ProductController : Controller
    {
        ThirdLabEntities db = new ThirdLabEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var data = db.Catagories.ToList();
            ViewBag.Catagories = data; 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)

        {
            if(ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                TempData["msg"] = "Product Created Successfully";
                return RedirectToAction("List");
            }
            return View(p);
        }
        public ActionResult List()
        {
            var products = db.Products.ToList();
            return View(products);
        }
        public ActionResult Details(Product p)
        {
            var product = db.Products.Find(p.Id);
            return View(product);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Catagories = db.Catagories.ToList();
            var product = db.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Update(Product p)
        {
            var obj = db.Products.Find(p.Id);
            
            // db.Entry(obj).CurrentValues.SetValues(p);  ei ek line diyeo update kora jay

            obj.Name = p.Name;
            obj.Price = p.Price;
            obj.CId = p.CId;
            obj.QTY = p.QTY;
            db.SaveChanges();
            TempData["msg"] = "Product Updated Successfully";
            return RedirectToAction("List");



        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Product p)
        {
            var product = db.Products.Find(p.Id);
            db.Products.Remove(product);
            db.SaveChanges();
            TempData["msg"] = "Product Deleted Successfully";
            return RedirectToAction("List");
        }
    }

}