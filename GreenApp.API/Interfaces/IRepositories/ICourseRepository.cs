using GreenCollege.API.Models;

namespace GreenCollege.API.Interfaces.IRepositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetCourses();
        Task<IEnumerable<Course>> GetCoursesAsync();
    }
}
