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
    internal class TeacherRepo : IRepositories<Teacher>
    {

        UniMS db;
        public TeacherRepo(UniMS db)
        {
            this.db = db;

        }
        public bool Create(Teacher entity)
        {
           var data = db.Teachers.Add(entity);
            return db.SaveChanges()>0;
            
        }

        public bool Delete(int id)
        {
            var data  = db.Teachers.Find(id);
            db.Teachers.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Teacher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
