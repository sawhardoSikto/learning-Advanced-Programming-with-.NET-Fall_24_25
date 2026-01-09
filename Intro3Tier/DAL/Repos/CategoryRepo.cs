using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CategoryRepo:IRepositories<Category>, ICategoryFeatures
    {
        EMSContext db;
        public CategoryRepo(EMSContext db)
        {
            this.db = db;
        }
        public List<Category> Get()
        {
            return db.Categories.ToList();

        }
        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }
        public bool Create(Category category)
        {
            db.Categories.Add(category);
            return db.SaveChanges() > 0;
        }
        public bool Update(Category category)
        {
            var exCategory = Get(category.Id);
            db.Entry(exCategory).CurrentValues.SetValues(category);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            return db.SaveChanges() > 0;
        }
        public Category GetByName(string name)
        {
            var cat = (from c in db.Categories
                       where c.Name.Contains(name)
                       select c).ToList().FirstOrDefault();
            return cat;
        }
        public List<Category> GetwithProduts()
        {
            var cat = (from c in db.Categories.Include(ct => ct.Products)

                       select c).ToList();
            return cat;
        }

    }
}
