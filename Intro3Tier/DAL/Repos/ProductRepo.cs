using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo: IRepositories<Product>
    {
        EMSContext db;
        public ProductRepo(EMSContext db)
        {
            this.db = db;
        }
        public List<Product> Get()
        {
            return db.Products.ToList();

        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
        public bool Create(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        public bool Update(Product product)
        {
            var exProduct = Get(product.Id);
            db.Entry(exProduct).CurrentValues.SetValues(product);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            return db.SaveChanges() > 0;
        }


    }
}
