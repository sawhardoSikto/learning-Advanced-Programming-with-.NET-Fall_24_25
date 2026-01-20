using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        TeacherService service;
        public TeachersController(TeacherService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var teachers = service.GetAll();
            return Ok(teachers);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var teacher = service.Get(id);
            return Ok(teacher);
        }
        [HttpPost("create")]
        public IActionResult Create(TeacherDTO dto)
        {
            var createdTeacher = service.Create(dto);
            if (createdTeacher)
            {
                return Ok("Teacher created successfully");
            }
            return BadRequest("Failed to create teacher");
        }
        [HttpPut("update")]
        public IActionResult Update(TeacherDTO dto)
        {
            var updatedTeacher = service.Update(dto);
            if (updatedTeacher)
            {
                return Ok("Teacher updated successfully");
            }
            return BadRequest("Failed to update teacher");
        }
        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var deletedTeacher = service.Delete(id);
            if (deletedTeacher)
            {
                return Ok("Teacher deleted successfully");
            }
            return BadRequest("Failed to delete teacher");
        }
    }
}
