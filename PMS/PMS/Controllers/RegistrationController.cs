using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class RegistrationController : Controller
    {
        PMSEntities db = new PMSEntities();

        public static Customer Convert(CustomerDTO c)
        {
            return new Customer
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Username = c.Username,
                Password = c.Password
            };
        }
        public static CustomerDTO Convert(Customer c)
        {
            return new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Username = c.Username,
                Password = c.Password
            };
        }

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new CustomerDTO());
        }
        [HttpPost]
        public ActionResult Register(CustomerDTO c)
        {
            if (ModelState.IsValid)
            {
                var customer = Convert(c);
                customer.Password = CreateMD5(c.Password);
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(c);
        }

        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" ensures lowercase hex format
                }
                return sb.ToString();
            }
        }
    }
}