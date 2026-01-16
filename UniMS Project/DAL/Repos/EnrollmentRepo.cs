using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EnrollmentRepo:IEnrollmentFeature
    {
        UniMS db;

        public EnrollmentRepo(UniMS db) 
        {
            this.db = db;
        }

        public bool Enroll(int sId, int cId, string semester)
        {
            var e = new Enrollment()
            {
                SId = sId,
                CId = cId,
                Semester = semester,
                Grade = null
            };

            db.Enrollments.Add(e);
            return db.SaveChanges() > 0;

        }

        public List<Enrollment> GetByStudent(int SId)
        {
            return (from e in db.Enrollments.Include("Course")
                    where e.SId == SId
                   select e).ToList();

        }

        public bool UpdateGrade(int Id, string Grade)
        {
            var ex = db.Enrollments.Find(Id);
            if (ex != null)
            {
                ex.Grade = Grade;
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
