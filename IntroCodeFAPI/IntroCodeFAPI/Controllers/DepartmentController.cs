using AutoMapper;
using IntroCodeFAPI.DTOs;
using IntroCodeFAPI.EF;
using IntroCodeFAPI.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCodeFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        UmsContext db;
        public DepartmentController(UmsContext db)
        {
            this.db = db;
        }
        Mapper Getmapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentDTO, Depertment>().ReverseMap();
            });
            return new Mapper(config);
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = db.Depertments.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = db.Depertments.Find(id);

            return Ok(data);

        }
        [HttpPost("create")]
        public IActionResult Create (DepartmentDTO dto)
        {
            var dept = Getmapper().Map<Depertment>(dto);
            db.Depertments.Add(dept);
            db.SaveChanges();
            return Ok(dept);

        }
    }
}