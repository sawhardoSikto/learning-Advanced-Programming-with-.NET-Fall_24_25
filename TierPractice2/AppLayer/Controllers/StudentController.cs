using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentService service;
        public StudentController(StudentService service)
        {
            this.service = service;
        }
        [HttpPost("create")]
        public IActionResult Create(StudentDTO dto)
        { 
            var result = service.Create(dto);
            return Ok(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var data = service.GetById(id);
            return Ok(data);
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, StudentDTO dto)
        {
            var result = service.Update(id, dto);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return Ok(result);
        }


    }
}
