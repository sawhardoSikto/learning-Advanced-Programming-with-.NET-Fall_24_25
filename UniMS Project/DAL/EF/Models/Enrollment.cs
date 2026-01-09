using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int SId { get; set; }
        [ForeignKey("Course")]
        public int CId { get; set; }
        public string Semester { get; set; }
        public string Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}
