using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class MapperConfig
    { 
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            cfg.CreateMap<Student, StudentEnrollmentDTO>().ReverseMap();

            cfg.CreateMap<Course, CourseDTO>().ReverseMap();
            cfg.CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
            cfg.CreateMap<Enrollment, EnrollmentCreateDTO>().ReverseMap();
            cfg.CreateMap<StudentCreateDTO, Student>();


        });
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }


    }
}
