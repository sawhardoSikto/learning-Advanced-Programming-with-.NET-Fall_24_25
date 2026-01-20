using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TeacherService
    {
        DataAccessFactory factory;
        public TeacherService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<TeacherDTO> GetAll()
        {
            var cfg = MapperConfig.GetMapper();
            var data = factory.TeacherData().GetAll();
            return cfg.Map<List<TeacherDTO>>(data);
        }
        public TeacherDTO Get(int id)
        {
            var cfg = MapperConfig.GetMapper();
            var data = factory.TeacherData().GetById(id);
            return cfg.Map<TeacherDTO>(data);
        }
        public bool Create(TeacherDTO teacherdto)
        {
            var cfg = MapperConfig.GetMapper();
            var teacher = cfg.Map<DAL.EF.Models.Teacher>(teacherdto);
            return factory.TeacherData().Create(teacher);
        }
        public bool Update(TeacherDTO teacherdto)
        {
            var cfg = MapperConfig.GetMapper();
            var teacher = cfg.Map<DAL.EF.Models.Teacher>(teacherdto);
            return factory.TeacherData().Update(teacher);
        }
        public bool Delete(int id)
        {
            return factory.TeacherData().Delete(id);
        }
    }
}
