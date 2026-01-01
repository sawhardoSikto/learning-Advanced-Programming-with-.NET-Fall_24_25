using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.EF.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService:IStudentService
    {
        GenericRepo<Student> repo;
        public StudentService(GenericRepo<Student> repo)
        {
            this.repo = repo;
        }
        Mapper Getmapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student,StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public bool Create (StudentDTO dto)
        {
            var mapper = Getmapper();
            var data = mapper.Map<Student>(dto);
            return repo.Create(data);
        }
        public List<StudentDTO> GetAll()
        {
            var data = repo.GetAll();
            var mapper = Getmapper();
            return mapper.Map<List<StudentDTO>>(data);
        }
        public StudentDTO GetById (int id)
        {
            var data = repo.GetById(id);
            var mapper = Getmapper();
            return mapper.Map<StudentDTO>(data);
        }
        public bool Update (int id, StudentDTO dto)
        {
            var mapper = Getmapper();
            var data = mapper.Map<Student>(dto);
            data.Id = id;
            return repo.Update(data);
        }
        public bool Delete (int id)
        {
            return repo.Delete(id);
        }
    }
}
