using IntroCoreDBFAPI.DTOs;
using IntroCoreDBFAPI.EF;
using IntroCoreDBFAPI.EF.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroCoreDBFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        FinalCrudContext db;


        public static Student Convert(StudentDTO sdto)
        {
            return new Student
            {

                Name = sdto.Name,
                Email = sdto.Email,
                DepartmentId = sdto.DepartmentId

            };
        }
        public static StudentDTO Convert(Student s)
        {
            return new StudentDTO
            {
                Name = s.Name,
                Email = s.Email,
                DepartmentId = s.DepartmentId,
                Department = new DepartmentDTO
                {
                    Id = s.Department.Id,
                    Name = s.Department.DepartmentName
                }
            };
        }
        public static List<StudentDTO> Convert(List<Student> students)
        {
            List<StudentDTO> list = new List<StudentDTO>();

            foreach (var s in students)
            {
                list.Add(Convert(s));   // single Student → DTO
            }

            return list;
        }

        public StudentController(FinalCrudContext db)
        {
            this.db = db;

        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = db.Students.Include(s => s.Department).ToList();//
            var dtoData = Convert(data);
            return Ok(dtoData);

        }
        [HttpPost]
        public IActionResult Create(StudentDTO sdto)
        {
            var dd = Convert(sdto);
            db.Students.Add(dd);
            db.SaveChanges();
            return Ok("Student Created"); 


        }


    }
}
