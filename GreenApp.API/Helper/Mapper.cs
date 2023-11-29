using AutoMapper;
using GreenCollege.API.DTOs.CourseDtos;
using GreenCollege.API.Models;
using GreenCollege.API.DTOs.AcademicYearDtos;
using GreenCollege.API.DTOs.SectionDtos;
using GreenCollege.API.DTOs.MajorDtos;
using GreenCollege.API.DTOs.DegreeDtos;

namespace GreenCollege.API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Degree, GetDegreeDto>();
            CreateMap<Degree, PostDegreeDto>();
            CreateMap<GetDegreeDto, Degree>();
            CreateMap<PostDegreeDto, Degree>();

            CreateMap<Major, GetMajorDto>();
            CreateMap<Major, PostMajorDto>();
            CreateMap<GetMajorDto, Major>();
            CreateMap<PostMajorDto, Major>();

            CreateMap<Course, GetCourseDto>();
            CreateMap<Course, PostCourseDto>();
            CreateMap<GetCourseDto, Course>();
            CreateMap<PostCourseDto, Course>();

            CreateMap<Section, GetSectionDto>();
            CreateMap<Section, PostSectionDto>();
            CreateMap<GetSectionDto, Section>();
            CreateMap<PostSectionDto, Section>();

            CreateMap<AcademicYear, GetAcademicYearDto>();
            CreateMap<AcademicYear, PostAcademicYearDto>();
            CreateMap<GetAcademicYearDto, AcademicYear>();
            CreateMap<PostAcademicYearDto, AcademicYear>();
        }
    }
}
