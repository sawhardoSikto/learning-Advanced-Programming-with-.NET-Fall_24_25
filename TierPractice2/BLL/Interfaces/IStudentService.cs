using BLL.DTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    internal interface IStudentService
    {
        bool Create(StudentDTO dto);
        List<StudentDTO> GetAll();
        StudentDTO GetById(int id);
        bool Update(int id, StudentDTO dto);
        bool Delete(int id);


    }
}
