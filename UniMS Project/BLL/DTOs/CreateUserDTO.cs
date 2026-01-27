using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CreateUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }   // or Email
        public string Password { get; set; }
        public string Role { get; set; }
        public int? ReferenceId { get; set; } // Student / Teacher / Admin
    }
}
