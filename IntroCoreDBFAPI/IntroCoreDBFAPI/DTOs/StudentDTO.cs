using System.ComponentModel.DataAnnotations;

namespace IntroCoreDBFAPI.DTOs
{
    public class StudentDTO
    {
       public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required,EmailAddress]
        public string? Email { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
     
        public DepartmentDTO? Department { get; set; }

    }
}
