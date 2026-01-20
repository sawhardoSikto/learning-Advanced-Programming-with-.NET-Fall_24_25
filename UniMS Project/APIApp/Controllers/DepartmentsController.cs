using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        DepartmentService service;
        public DepartmentsController(DepartmentService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var departments = service.GetAll();
            return Ok(departments);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = service.Get(id);
            return Ok(department);
        }
        [HttpPost("create")]
        public IActionResult Create(DepartmentDTO dto)
        {
            var createdDepartment = service.Create(dto);
            if (createdDepartment)
            {
                return Ok("Department created successfully");
            }
            return BadRequest("Failed to create department");
        }
        [HttpPut("update")]
        public IActionResult Update(DepartmentDTO dto)
        {
            var updatedDepartment = service.Update(dto);
            if (updatedDepartment)
            {
                return Ok("Department updated successfully");
            }
            return BadRequest("Failed to update department");
        }
        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var deletedDepartment = service.Delete(id);
            if (deletedDepartment)
            {
                return Ok("Department deleted successfully");
            }
            return BadRequest("Failed to delete department");
        }

    }
}
