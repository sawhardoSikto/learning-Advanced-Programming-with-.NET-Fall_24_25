using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCodeFAPI.EF.Models
{
    public class Depertment
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Dname { get; set; }
    }
}
