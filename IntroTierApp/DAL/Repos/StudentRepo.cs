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
        public bool Create (Student s)
        {
            db.Students.Add(s);
            return db.SaveChanges() > 0;
        }
        public List<Student> Get()
        {
            return db.Students.ToList();
        }

    }
}
