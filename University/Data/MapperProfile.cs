using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DTO;
using University.Models.Entities;
using University.Models.ViewModels;

namespace University.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentListViewModel>();
            CreateMap<Student, StudentAddViewModel>().ReverseMap();

            CreateMap<Student, StudentDetailsViewModel>()
                .ForMember(
                        dest => dest.Attending,
                        from => from.MapFrom(s => s.Enrollments.Count))
                .ForMember(
                        dest => dest.Courses,
                        from => from.MapFrom(s => s.Enrollments.Select(e => e.Course).ToList()));
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Enrollment, EnrollementDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();

        }
    }
}
