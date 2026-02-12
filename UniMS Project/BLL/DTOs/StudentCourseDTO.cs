using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentCourseDTO
    {
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public int Credit { get; set; }
        public string Semester { get; set; }
        public string Grade { get; set; }
    }
}
