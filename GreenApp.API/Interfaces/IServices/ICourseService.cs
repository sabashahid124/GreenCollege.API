using GreenCollege.API.DTOs.CourseDtos;

namespace GreenCollege.API.Interfaces.IServices
{
    public interface ICourseService
    {
        Task<IEnumerable<GetCourseDto>> GetAllCoursesAsync();
        Task<GetCourseDto> GetCourseByIdAsync(int id);
        void Add(PostCourseDto degreeDto);
        void Update(GetCourseDto degreeDto);
        void Remove(GetCourseDto degreeDto);
        Task Complete();
        void Dispose();
    }
}
