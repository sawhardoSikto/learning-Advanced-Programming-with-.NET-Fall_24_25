using mid2.DTOs;
using mid2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;

namespace mid2.Controllers
{
    public class ProductController : Controller
    {
        ThirdLabEntities db = new ThirdLabEntities();
        // GET: Product

        public static ProductDTO Convert(Product p)
        {
            return new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                QTY = p.QTY,
                CId = p.CId,
                Catagory = p.Catagory
            };
        }
        public static Product Convert(ProductDTO p)
        {
            return new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                QTY = p.QTY,
                CId = p.CId,
                Catagory = p.Catagory
            };
        }
        public static List<ProductDTO> Convert(List<Product> products)
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (var p in products)
            {
                productDTOs.Add(Convert(p));
            }
            return productDTOs;
        }
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
        public ActionResult Create(ProductDTO p)

        {
            if(ModelState.IsValid)
            {
                var pt = Convert(p);
                db.Products.Add(pt);
                db.SaveChanges();
                TempData["msg"] = "Product Created Successfully";
                return RedirectToAction("List");
            }
            var data = db.Catagories.ToList();
            ViewBag.Catagories = data;
            return View(p);
        }
        public ActionResult List(string search)
        {
            if (search != null)
            {
                var filtered = (from pro in db.Products
                                where pro.Name.Contains(search)
                                select pro).ToList();
                return View(filtered);

            }
            //var data = (from pro in db.Products     //ei line gulo diyeo kora jay
            //            select pro).ToList();         //comment gulo ar ar nicher line eki
            //return View(data);
            var products = db.Products.ToList();
            return View(Convert(products));
        }
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
           // ViewBag.Catagories = db.Catagories.ToList();
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