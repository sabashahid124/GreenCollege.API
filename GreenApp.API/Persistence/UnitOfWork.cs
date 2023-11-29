using GreenCollege.API.Persistence.Repositories;
using GreenCollege.API.Data;
using GreenCollege.API.Interfaces;
using GreenCollege.API.Interfaces.IRepositories;

namespace GreenCollege.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GreenCollegeDbContext _context;

        public UnitOfWork(GreenCollegeDbContext context)
        {
            _context = context;
            DegreeRepository = new DegreeRepository(_context);
            MajorRepository = new MajorRepository(_context);
            CourseRepository = new CourseRepository(_context);
            SectionRepository = new SectionRepository(_context);
            AcademicYearRepository = new AcademicYearRepository(_context);
        }

        // Course Regulation Repositories
        public IDegreeRepository DegreeRepository { get; private set; }
        public IMajorRepository MajorRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public ISectionRepository SectionRepository { get; private set; }
        public IAcademicYearRepository AcademicYearRepository { get; private set; }

        //Unit of Work
        public async Task Complete() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();

    }
}
