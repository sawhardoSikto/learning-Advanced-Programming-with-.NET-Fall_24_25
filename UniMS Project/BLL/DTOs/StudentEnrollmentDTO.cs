using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public  class StudentEnrollmentDTO:StudentDTO
    {
        public List<EnrollmentDTO> Enrollments { get; set; }
        public StudentEnrollmentDTO()
        {
            Enrollments = new List<EnrollmentDTO>();
        }
    }
}
