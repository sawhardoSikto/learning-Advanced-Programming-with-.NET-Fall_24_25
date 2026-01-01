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
        [HttpGet("all")]
        public IActionResult Get()
        {
            var data = service.Getall();
            return Ok(data);

        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var data = service.GetId(id);
            return Ok(data);

        }


        [HttpPost("create")]
        public IActionResult Create(StudentDTO s)
        {
            var res = service.Create(s);
            return Ok(res);

        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var res = service.delete(id);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentDTO dto)
        {
            var res = service.update(id,dto);
            return Ok(res);
        }


    }
}


