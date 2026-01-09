using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        
        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }
        public Department() {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Courses = new List<Course>();
        }



    }
}
