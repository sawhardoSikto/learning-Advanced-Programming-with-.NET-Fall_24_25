using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace IntroCodeFAPI.EF.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string Name { get; set; }
        [ForeignKey("dept")]    
        public int Did { get; set; }
        public Depertment    dept { get; set; }


    }
}
