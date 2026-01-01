using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo repo;
        public StudentService(StudentRepo repo) { 
            this.repo = repo;
        }
        Mapper GetMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Student,StudentDTO>().ReverseMap();
                    
               
                }
                );
            return new Mapper(config);
        }

        public bool Create(StudentDTO dto)
        {
            var mapper = GetMapper();
            var data = mapper.Map<Student>(dto);
            return repo.create(data);
        }
        public List<StudentDTO> Getall()
        {
            var data = repo.Getall();
            var mapper = GetMapper();
            var dto = mapper.Map<List<StudentDTO>>(data);
            return dto;
        }
        public List<StudentDTO> GetId(int id)
        {
            var data = repo.GetId(id);
            var mapper = GetMapper();
            var dto = mapper.Map<List<StudentDTO>>(data);
            return dto;
        }
        public bool delete(int id)
        {
            return repo.delete(id);
        }
        public bool update(int id,StudentDTO dto)
        {
            var mapper = GetMapper();
            var data = mapper.Map<Student>(dto);
            data.Id = id;
            return repo.update(data);
        }

    }
}
