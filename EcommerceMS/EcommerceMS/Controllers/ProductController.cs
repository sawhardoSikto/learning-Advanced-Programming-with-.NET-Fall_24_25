using AutoMapper;
using EcommerceMS.DTOs;
using EcommerceMS.EF;
using EcommerceMS.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        EmsContext db;
        public ProductController(EmsContext db) 
            {
            this.db = db;


            }

        Mapper Getmapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>().ReverseMap();


            });
            return new Mapper(config);
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = db.Products.ToList();
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(ProductDTO dto) 
            {
            var pro = Getmapper().Map<Product>(dto);
            db.Products.Add(pro);
            db.SaveChanges();
            return Ok(pro);


        }


        
    }
}
