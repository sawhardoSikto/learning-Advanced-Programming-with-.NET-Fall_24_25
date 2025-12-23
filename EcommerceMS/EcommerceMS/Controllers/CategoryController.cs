using AutoMapper;
using EcommerceMS.DTOs;
using EcommerceMS.EF;
using EcommerceMS.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerceMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        EmsContext db;
        public CategoryController(EmsContext db)
        {
            this.db = db;
        }
        Mapper Getmapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>().ReverseMap();


            });
            return new Mapper(config);
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = db.Categories.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.Categories.Find(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create (CategoryDTO dto)
        {
            var cate = Getmapper().Map<Category>(dto);
            db.Categories.Add(cate);
            db.SaveChanges();
            return Ok(cate);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cate = db.Categories.Find(id);
            if(cate != null)
            {
                db.Categories.Remove(cate);
                db.SaveChanges();
                return Ok();
            }
            return NotFound("Category not found");
        }
       



    }
}
