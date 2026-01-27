using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
 

        [ApiController]
        [Route("api/auth")]
        public class AuthController : ControllerBase
        {
            AuthService service;

            public AuthController(AuthService service)
            {
                this.service = service;
            }

            [HttpPost("login")]
            public IActionResult Login(LoginDTO dto)
            {
                var token = service.Login(dto.Username, dto.Password);

                if (token == null)
                    return Unauthorized("Invalid credentials");

                return Ok(new { token });
            }
        }

    }

