using BLL.DTOs;
using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        UniMS db;

        public AdminService(UniMS db)
        {
            this.db = db;
        }

        public bool CreateUser(CreateUserDTO dto)
        {
            // 🔐 Validation
            if (dto.Role == "Student")
            {
                if (db.Students.Find(dto.ReferenceId) == null)
                    return false;
            }

            if (dto.Role == "Teacher")
            {
                if (db.Teachers.Find(dto.ReferenceId) == null)
                    return false;
            }

            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = dto.Role,
                ReferenceId = dto.ReferenceId
            };

            db.Users.Add(user);
            return db.SaveChanges() > 0;
        }
    }
}

