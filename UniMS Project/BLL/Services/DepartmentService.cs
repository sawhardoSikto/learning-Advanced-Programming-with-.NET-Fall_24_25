using AutoMapper;
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
    public class DepartmentService
    {
        DataAccessFactory factory;
        public DepartmentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<DepartmentDTO> GetAll()
        {
            var cfg = MapperConfig.GetMapper();
            var data = factory.DepartmentData().GetAll();
             return cfg.Map<List<DepartmentDTO>>(data);
            
        }
        public DepartmentDTO Get(int id)
        {
            var cfg = MapperConfig.GetMapper();
            var data = factory.DepartmentData().GetById(id);
            return cfg.Map<DepartmentDTO>(data);
        }
        public bool Create(DepartmentDTO deptdto)
        {
            var cfg = MapperConfig.GetMapper();
            var dept = cfg.Map<Department>(deptdto);
            return factory.DepartmentData().Create(dept);
        }
        public bool Update(DepartmentDTO deptdto)
        {
            var cfg = MapperConfig.GetMapper();
            var dept = cfg.Map<Department>(deptdto);
            return factory.DepartmentData().Update(dept);
        }
        public bool Delete(int id)
        {
            return factory.DepartmentData().Delete(id);
        }

    }
}
