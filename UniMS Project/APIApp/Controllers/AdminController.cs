using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AdminService service;

        public AdminController(AdminService service)
        {
            this.service = service;
        }
        [HttpPost("create-user")]
        public IActionResult CreateUser(CreateUserDTO dto)
        {
            var res = service.CreateUser(dto);
            if (res)
            {
                return Ok("User Created");
            }
            return BadRequest("User Not Created");
        }
    }
}
