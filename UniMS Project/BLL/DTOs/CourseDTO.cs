using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public  class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }

    }
}
