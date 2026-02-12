using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentDashboardDTO
    {
        public string Name { get; set; }
        public string StudentID { get; set; }
        public double Cgpa { get; set; }
        public string Status { get; set; }

        public List<StudentCourseDTO> Courses { get; set; }

        public StudentDashboardDTO()
        {
            Courses = new List<StudentCourseDTO>();
        }
    }
}
