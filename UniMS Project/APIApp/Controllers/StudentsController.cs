using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentService service;
        public StudentsController(StudentService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            var students = service.GetAll();
            return Ok(students);
        }

        [HttpPost("create")]
        public IActionResult Create(StudentCreateDTO dto)
        {
            bool result  = service.Create(dto);
            if (result)
            {
                return Ok("Student created successfully" );
            }
            else
            {
                return BadRequest("Failed to create student");
            }
        }

        [HttpGet("{id}/cgpa")]
        public IActionResult GetCGPA(int id)
        {
            double cgpa = service.CalculateCgpa(id);
            return Ok(cgpa);

        }
        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id)
        {
            bool result = service.UpdateStudentStatus(id);
            if (result)
            {
                return Ok("Student status updated successfully");
            }
            else
            {
                return BadRequest("Failed to update student status");
            }
        }
        [HttpGet("search")]
        public IActionResult Search(string keyword)
        {
            var data = service.SearchStudents(keyword);
            return Ok(data);

        }


    }
}
