using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EnrollmentGradeDTO
    {
        public int EnrollmentId { get; set; }
        public string Grade { get; set; }
        public int StudentId { get; set; }
    }
}
