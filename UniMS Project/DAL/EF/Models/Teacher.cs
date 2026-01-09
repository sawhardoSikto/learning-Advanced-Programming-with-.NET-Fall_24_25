using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        [ForeignKey("Dept")]
        public int DepartmentId { get; set; }
        public virtual Department Dept { get; set; }
       
    }
}
