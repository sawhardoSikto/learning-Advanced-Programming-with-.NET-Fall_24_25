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
    internal class CourseRepo: IRepositories<Course>
    {
        UniMS db;
        public CourseRepo(UniMS db)
        {
            this.db = db;
        }

        public bool Create(Course entity)
        {
            var data = db.Courses.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Courses.Find(id);
            db.Courses.Remove(data);
            return db.SaveChanges() > 0;

        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Update(Course entity)
        {
            var data= GetById(entity.Id);
            db.Entry(data).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;

        }
    }
}
