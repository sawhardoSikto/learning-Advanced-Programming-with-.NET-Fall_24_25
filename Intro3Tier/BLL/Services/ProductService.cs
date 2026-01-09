using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        DataAccessFactory factory;
        public ProductService(DataAccessFactory factory) 
        {
            this.factory = factory;
        }
        public List<ProductDTO> Get()
        {
            var data = factory.ProductData().Get();
            var cfg = MapperConfig.GetMapper();
            return cfg.Map<List<ProductDTO>>(data);

        }
        public ProductDTO Get(int id)
        {
            var data = factory.ProductData().Get(id);
            var cfg = MapperConfig.GetMapper();
            return cfg.Map<ProductDTO>(data);
        }
        public bool Create(ProductDTO product)
        {
            var cfg = MapperConfig.GetMapper();
            var cat = cfg.Map<Product>(product);
            return factory.ProductData().Create(cat);
        }
        public bool Update(ProductDTO product)
        {
            var cfg = MapperConfig.GetMapper();
            var cat = cfg.Map<Product>(product);
            return factory.ProductData().Update(cat);
        }
        public bool Delete(int id)
        {
            return factory.ProductData().Delete(id);
        }
    }
}
