using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        EnrollmentService service;
        StudentService StudentService;
        public EnrollmentsController(EnrollmentService service, StudentService StudentService)
        {
            this.service = service;
            this.StudentService = StudentService;

        }

        [HttpPost("enroll")]
        public IActionResult Enroll(EnrollmentCreateDTO dto)
        {
            bool result = service.Enroll(dto);
            if (result)
            {
                return Ok( "Enrollment successful" );
            }
            return BadRequest("Enrollment failed" );
        }
        [HttpPut("grade/{id}")]
        [HttpPut("grade")]
        public IActionResult UpdateGrade(EnrollmentGradeDTO dto)
        {
            bool result = service.UpdateGrade(dto.EnrollmentId, dto.Grade);

            if (!result)
                return BadRequest("Grade update failed");

            StudentService.UpdateStudentStatus(dto.StudentId);

            return Ok("Grade updated successfully");
        }

        [HttpGet("gpa/{sid}/{semester}")]
        public IActionResult GetSemesterGPA(int sid,string semester)
        {
            double gpa = service.CalculateSemesterGPA(sid, semester);
            return Ok(gpa);
        }
       

    }
}
