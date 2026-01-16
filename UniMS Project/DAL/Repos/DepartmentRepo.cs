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
    internal class DepartmentRepo : IRepositories<Department>
    {
        UniMS db;
        public DepartmentRepo(UniMS db)
        {
            this.db = db;   
        }
        public bool Create(Department entity)
        {
            var data = db.Departments.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Departments.Find(id);
            db.Departments.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Department> GetAll()
        {
           return db.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.Find(id);
        }

        public bool Update(Department entity)
        {
           
            db.Entry(GetById(entity.Id)).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }
    }
}
