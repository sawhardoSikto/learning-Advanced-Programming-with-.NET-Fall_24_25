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
            cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
            cfg.CreateMap<Teacher, TeacherDTO>().ReverseMap();
            cfg.CreateMap<Student, StudentDashboardDTO>().ReverseMap();
            cfg.CreateMap<Enrollment, StudentCourseDTO>()
             .ForMember(dest => dest.CourseTitle,
                        opt => opt.MapFrom(src => src.Course.Title))
             .ForMember(dest => dest.CourseCode,
                        opt => opt.MapFrom(src => src.Course.Code))
             .ForMember(dest => dest.Credit,
                        opt => opt.MapFrom(src => src.Course.Credit));






        });
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }


    }
}
