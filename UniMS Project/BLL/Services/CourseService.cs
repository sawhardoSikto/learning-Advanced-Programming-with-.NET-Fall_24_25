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
    public class CourseService
    {
        DataAccessFactory factory;
        public CourseService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<CourseDTO> GetAll()
        {
                       var cfg = MapperConfig.GetMapper();
            var data = factory.CourseData().GetAll();
             return cfg.Map<List<CourseDTO>>(data);


        }
        public CourseDTO Get(int id)
        {
            var cfg = MapperConfig.GetMapper();
            var data = factory.CourseData().GetById(id);
            return cfg.Map<CourseDTO>(data);
        }
        public bool Create(CourseDTO coursedto)
        {
            var cfg = MapperConfig.GetMapper();
            var course = cfg.Map<DAL.EF.Models.Course>(coursedto);
            return factory.CourseData().Create(course);
        }
        public bool Update(CourseDTO coursedto)
        {
            var cfg = MapperConfig.GetMapper();
            var course = cfg.Map<Course>(coursedto);
            return factory.CourseData().Update(course);
        }
        public bool Delete(int id)
        {
            return factory.CourseData().Delete(id);
        }
    }
}
