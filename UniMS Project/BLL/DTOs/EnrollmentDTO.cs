using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }
 
        public string Semester { get; set; }
        public string Grade { get; set; }

        public CourseDTO Course { get; set; }
    }
}
