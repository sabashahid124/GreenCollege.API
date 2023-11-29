using AutoMapper;
using GreenCollege.API.DTOs.CourseDtos;
using GreenCollege.API.Interfaces;
using GreenCollege.API.Interfaces.IServices;
using GreenCollege.API.Models;

namespace GreenCollege.API.Persistence.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCourseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetCoursesAsync();
            return _mapper.Map<IEnumerable<GetCourseDto>>(courses);
        }

        public async Task<GetCourseDto> GetCourseByIdAsync(int id)
        {
            var courses = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            return _mapper.Map<GetCourseDto>(courses);
        }

        public void Add(PostCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _unitOfWork.CourseRepository.Add(course);
        }

        public void Update(GetCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _unitOfWork.CourseRepository.Update(course);
        }

        public void Remove(GetCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _unitOfWork.CourseRepository.Remove(course);
        }

        public async Task Complete() => await _unitOfWork.Complete();

        public void Dispose() => _unitOfWork.Dispose();
    }
}

