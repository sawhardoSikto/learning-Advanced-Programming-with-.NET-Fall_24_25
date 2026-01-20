using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        UniMS db;
        public DataAccessFactory(UniMS db)
        {
            this.db = db;

        }
        public IRepositories<Student> StudentData()
        {
            return new StudentRepo(db);
        }
        public IRepositories<Teacher> TeacherData()
        {
            return new TeacherRepo(db);
        }
        public IRepositories<Department> DepartmentData()
        {
            return new DepartmentRepo(db);
        }
        public IRepositories<Course> CourseData()
        {
            return new CourseRepo(db);
        }
        public IEnrollmentFeature EnrollmentData()
        {
            return new EnrollmentRepo(db);
        }
       public IStudentFeatures StudentFeaturesData()
        {
            return new StudentRepo(db);
        }

    }
}
