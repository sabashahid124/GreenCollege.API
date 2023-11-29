using GreenCollege.API.Interfaces.IRepositories;

namespace GreenCollege.API.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Course Regulation IRepositories
        IDegreeRepository DegreeRepository { get; }
        IMajorRepository MajorRepository { get; }
        ICourseRepository CourseRepository { get; }
        ISectionRepository SectionRepository { get; }
        IAcademicYearRepository AcademicYearRepository { get; }

        //Unit of Work
        Task Complete();
    }
}
