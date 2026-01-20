using BLL.DTOs;
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
    public class EnrollmentService
    {
        DataAccessFactory factory;
       public EnrollmentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        
        // Student same course same semester 2 bar nite parbe na
        public bool Enroll(EnrollmentCreateDTO dto)
        {
            List<Enrollment> list = factory.EnrollmentData().GetByStudent(dto.SId);
            foreach (var enrollment in list)
            {
                if (enrollment.CId == dto.CId && enrollment.Semester == dto.Semester)
                {
                    return false; 
                }
            }
          
            return factory.EnrollmentData().Enroll(dto.SId,dto.CId,dto.Semester);
        }
        public bool UpdateGrade(int Id, string Grade)
        {
            return factory.EnrollmentData().UpdateGrade(Id,Grade);
        }

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
            if (totalCredit == 0)
                return 0.0;
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
