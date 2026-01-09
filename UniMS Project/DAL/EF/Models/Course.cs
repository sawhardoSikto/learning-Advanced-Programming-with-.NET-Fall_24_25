using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        [ForeignKey("Dept")]
        public int DepartmentId { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Department Dept { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual List<Enrollment> Enrollments { get; set; }
        public Course()
        {
            Enrollments = new List<Enrollment>();
        }
    }
}
