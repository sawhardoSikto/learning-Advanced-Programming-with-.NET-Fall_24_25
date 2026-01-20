using BLL.DTOs;
using BLL.Services;
using DAL.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        CourseService service;
        public CoursesController(CourseService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
                 

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var c = service.Get(id);
            return Ok(c);
        }
        [HttpPost("create")]
        public IActionResult Create(CourseDTO course)
        {
            var res = service.Create(course);
            if (res)
            {
                return Ok("Course Created");
            }
            return BadRequest("Course Not Created");
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id); 
            return Ok(); 
        }
        [HttpPut("update")]
        public IActionResult Update(CourseDTO course)
        {
            var data = service.Update(course);
            if(data)
            {
                return Ok("Updated");

            }
            return BadRequest("not Updated");

            
        }

    }
}
