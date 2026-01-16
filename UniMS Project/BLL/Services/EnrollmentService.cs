using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class EnrollmentService
    {
        DataAccessFactory factory;
        EnrollmentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        // FEATURE 1: Advanced validation
        // Student same course same semester 2 bar nite parbe na
        public bool Enroll(int sId, int cId, string semester)
        {
            List<Enrollment> list = factory.EnrollmentData().GetByStudent(sId);
            foreach (var enrollment in list)
            {
                if (enrollment.CId == cId && enrollment.Semester == semester)
                {
                    return false; // Student is already enrolled in this course for the given semester
                }
            }
          
            return factory.EnrollmentData().Enroll(sId,cId,semester);
        }
        public bool UpdateGrade(int Id, string Grade)
        {
            return factory.EnrollmentData().UpdateGrade(Id,Grade);
        }
        // FEATURE 3: REPORT / ANALYTICS
        // Semester wise GPA calculation
        public double CalculateSemesterGPA(int sId, string semester)
        {
            List<Enrollment> list = factory.EnrollmentData().GetByStudent(sId);

            double totalPoints = 0;
            int totalCredit = 0;
            foreach(Enrollment e in list)
            {
                if (e.Semester == semester && e.Grade !=null)
                {
                    double points = GradeToPoint(e.Grade);
                    totalPoints += points * e.Course.Credit;
                    totalCredit  += e.Course.Credit;

                }
            }
            return totalPoints/totalCredit;



        }
       


        public double GradeToPoint(string grade)
        {
            if (grade == "A+")
            {
                return 4.00;
            }
            if (grade == "A")
            {
                return 3.75;
            }
            if (grade == "B+")
            {
                return 3.50;

            }
            if (grade == "B")
            {
                return 3.25;
            }
            if (grade == "C+")
            {
                return 3.00;
            }
            if (grade == "C")
            {
                return 2.75;
            }
            if (grade == "D")
            {
                return 2.50;
            }
            return 0.0;
        }
    }
}
