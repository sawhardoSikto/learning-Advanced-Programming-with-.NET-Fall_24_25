using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService service;
        public CategoryController(CategoryService service) 
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult Get()
        {
            var data = service.Get();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(CategoryDTO category)
        {
            var res = service.Create(category);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult Update(CategoryDTO category)
        {
            var res = service.Update(category);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            return Ok(res);
        }

        [HttpGet("all/products")]
        public IActionResult GetwithProducts()
        {
            var data = service.GetwithProducts();
            return Ok(data);
        }

    }
}
