using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.MapperConfig;

namespace BLL.Services
{
    public class CategoryService
    {
        DataAccessFactory factory;
        public CategoryService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<CategoryDTO> Get()
        {
            var data = factory.CategoryData().Get();
            var cfg = MapperConfig.GetMapper();
            return cfg.Map<List<CategoryDTO>>(data);

        }
        public CategoryDTO Get(int id)
        {
            var data = factory.CategoryData().Get(id);
            var cfg = MapperConfig.GetMapper();
            return cfg.Map<CategoryDTO>(data);
        }
        public bool Create(CategoryDTO category)
        {
            var cfg = MapperConfig.GetMapper();
            var cat = cfg.Map<Category>(category);
            return factory.CategoryData().Create(cat);
        }
        public bool Update(CategoryDTO category)
        {
            var cfg = MapperConfig.GetMapper();
            var cat = cfg.Map<Category>(category);
            return factory.CategoryData().Update(cat);
        }
        public bool Delete(int id)
        {
            return factory.CategoryData().Delete(id);
        }
        public CategoryDTO GetByName(string name)
        {
            var data = factory.CategoryFeatures().GetByName(name);
            var cfg = MapperConfig.GetMapper();
            return cfg.Map<CategoryDTO>(data);
        }
        public List<CategoryProductDTO> GetwithProducts()
        {
            var data = factory.CategoryFeatures().GetwithProduts();
            var cfg = MapperConfig.GetMapper();
            return cfg.Map<List<CategoryProductDTO>>(data);
        }
    }
}
