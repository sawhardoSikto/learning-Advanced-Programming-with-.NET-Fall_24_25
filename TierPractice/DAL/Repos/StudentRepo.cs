using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
        UMSContext db;
        public StudentRepo(UMSContext db)
        {
            this.db = db;
        }
        public bool create(Student s)
        {
            db.students.Add(s);
            return db.SaveChanges() > 0;
        }
        public List<Student> GetId(int id)
        {
            var data = (from i in db.students
                        where i.Id == id
                        select i).ToList();
            return data;
        }
        public List<Student> Getall() {
            var data = db.students.ToList();
            return data;
        }
        public bool delete(int id)
        {
            var student = db.students.Find(id);
            if (student != null)
            {
                db.students.Remove(student);
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public bool update(Student s)
        {
            var existing = db.students.Find(s.Id);

            if (existing == null)
                return false;

            existing.Name = s.Name;
            

            return db.SaveChanges() > 0;
        }



    }
}
