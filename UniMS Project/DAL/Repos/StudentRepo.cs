using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepo:IRepositories<Student> , IStudentFeatures
    {
        UniMS db;
        public StudentRepo (UniMS db)
        {
            this.db = db;

        }

        public bool Create(Student entity)
        {
           db.Students.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var category = db.Students.Find(id);
            db.Students.Remove(category);
            return db.SaveChanges() > 0;
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetById(int id)
        {
            return db.Students.Find(id);
        }

        public bool Update(Student entity)
        {
            var exCategory = GetById(entity.Id);
            db.Entry(exCategory).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }
        public List<Student> GetWithEnrollment()
        {
            var students = (from s in db.Students.Include(st => st.Enrollments).ThenInclude(e=> e.Course)
                            select s).ToList();
            return students;
        }
        public Student GetWithEnrollmentById(int id)
        {
            var student = (from s in db.Students.Include(st => st.Enrollments).ThenInclude(e => e.Course)
                           where s.Id == id
                           select s).FirstOrDefault();
            return student;
        }

        public Student GetByUsername(int id)
        {
            var student = (from s in db.Students
                           where s.Id == id
                           select s).FirstOrDefault();

            return student;
        }

        public List<Enrollment> GetEnrollments(int sid)
        {
            var enrollments = (from e in db.Enrollments
                               where e.SId == sid
                               select e)
                       .Include(e => e.Course)
                       .ToList();

            return enrollments;
        }
    }
}
