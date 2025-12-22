using System.ComponentModel.DataAnnotations;

namespace IntroCodeFAPI.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DName { get; set; }
    }
}
