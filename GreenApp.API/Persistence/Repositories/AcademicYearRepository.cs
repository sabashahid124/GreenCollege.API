using GreenCollege.API.Data;
using GreenCollege.API.Interfaces.IRepositories;
using GreenCollege.API.Models;

namespace GreenCollege.API.Persistence.Repositories
{
    public class AcademicYearRepository : Repository<AcademicYear>, IAcademicYearRepository
    {
        public AcademicYearRepository(GreenCollegeDbContext _context)
     : base(_context)
        {
        }
        public IEnumerable<AcademicYear> GetAcademicYears()
        {
            return dbContext.AcademicYears.ToList();
        }

        //public IEnumerable<AcademicYear> GetAcademicYears()
        //{
        //    return dbContext.AcademicYears
        //        .Include(a => a.Degree)
        //        .ToList();
        //}

        //public async Task<IEnumerable<AcademicYear>> GetAcademicYearsAsync()
        //{
        //    return await dbContext.AcademicYears
        //        .Include(a => a.Degree)
        //        .ToListAsync().ConfigureAwait(false);
        //}

        public GreenCollegeDbContext dbContext => _context as GreenCollegeDbContext;

    }
}
