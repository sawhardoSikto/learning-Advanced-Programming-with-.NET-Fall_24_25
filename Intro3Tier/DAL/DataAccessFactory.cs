using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        EMSContext db;
        public DataAccessFactory(EMSContext db) 
        {
            this.db= db;
        }
        public IRepositories<Category> CategoryData()
        {
            return new CategoryRepo(db);
        }
        public IRepositories<Product> ProductData()
        {
            return new ProductRepo(db);
        }
        public ICategoryFeatures CategoryFeatures()
        {
            return new CategoryRepo(db);
        }
    }
}
