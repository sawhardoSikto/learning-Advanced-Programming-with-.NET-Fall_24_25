using BLL.DTOs;
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
      


        DataAccessFactory factory;
        MailService mailService;
        public StudentService(DataAccessFactory factory , MailService mailService)
        {
            this.factory = factory;
            this.mailService = mailService;
        }

        public bool Create(StudentCreateDTO studentdto)
        {
            var cfg = MapperConfig.GetMapper();
            var student = cfg.Map<Student>(studentdto);
            student.Cgpa = 0.0;
            student.Status= "Active";
            return factory.StudentData().Create(student);
        }
        public List<StudentDTO> GetAll()
        {
            var cfg = MapperConfig.GetMapper();
            var students = factory.StudentData().GetAll();
            return cfg.Map<List<StudentDTO>>(students);
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
                    double points = GradeToPoint(e.Grade);
                    totalPoint += points * e.Course.Credit;
                    totalCredit += e.Course.Credit;

                }
            }
            if (totalCredit == 0)
                return 0.0;
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
                if(!string.IsNullOrEmpty(s.Status))
                
                {
                    mailService.SendProbationMail(s.Email, s.Name, cgpa);
                }
            }
            else
            {
                s.Status = "Active";
            }
            return factory.StudentData().Update(s);


        }

        // advanced search
        public List<StudentDTO> SearchStudents(string keyword)
        {
            var cfg = MapperConfig.GetMapper();
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

            return cfg.Map<List<StudentDTO>>(result);
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
