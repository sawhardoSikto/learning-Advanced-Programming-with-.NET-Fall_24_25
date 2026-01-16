using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class StudentService
    {
        EnrollmentService sc; // for GradeToPoint method


        DataAccessFactory factory;
        public StudentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public double CalculateCgpa(int SId)
        {
            List<Enrollment> list = factory.EnrollmentData().GetByStudent(SId);

            double totalPoint = 0;
            double totalCredit = 0;

            foreach (Enrollment e in list)
            {
                if ( e.Grade != null)
                {
                    double points = sc.GradeToPoint(e.Grade);
                    totalPoint += points * e.Course.Credit;
                    totalCredit += e.Course.Credit;

                }
            }
            return totalPoint / totalCredit;

        }

        // FEATURE 5: WORKFLOW AUTOMATION
        // CGPA < 2.0 hole auto Probation
        public bool UpdateStudentStatus(int SId)
        {
            Student s = factory.StudentData().GetById(SId);
            if (s == null)
            {
                return false;
            }
            double cgpa = CalculateCgpa(SId);
            if (cgpa < 2.50)
            {
                s.Status = "Probation";
            }
            else
            {
                s.Status = "Active";
            }
            return factory.StudentData().Update(s);


        }

        // advanced search
        public List<Student> SearchStudents(string keyword)
        {
            List<Student> list =
                factory.StudentData().GetAll();

            List<Student> result = new List<Student>();

            foreach (Student s in list)
            {
                if (s.Name.ToLower().Contains(keyword.ToLower()) ||
                    s.Email.ToLower().Contains(keyword.ToLower()))
                {
                    result.Add(s);
                }
            }

            return result;
        }


    }
}
