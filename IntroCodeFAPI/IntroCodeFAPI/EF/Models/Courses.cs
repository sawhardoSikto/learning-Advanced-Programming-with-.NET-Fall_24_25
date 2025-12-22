using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCodeFAPI.EF.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Cname { get; set; }
        [ForeignKey("dept")]
        public int Did { get; set; }
        public Depertment dept { get; set; }
    }
}
