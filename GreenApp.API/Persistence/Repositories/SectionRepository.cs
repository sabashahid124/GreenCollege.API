using GreenCollege.API.Data;
using GreenCollege.API.Interfaces.IRepositories;
using GreenCollege.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenCollege.API.Persistence.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(GreenCollegeDbContext _context)
                : base(_context)
        {
        }

        public IEnumerable<Section> GetSections()
        {
            return dbContext.Sections
                .Include(s => s.Course)
                .Include(s => s.AcademicYear)
                    .ToList();
        }

        public async Task<IEnumerable<Section>> GetSectionsAsync()
        {
            return await dbContext.Sections
                .Include(s => s.Course)
                .Include(s => s.AcademicYear)
                    .ToListAsync().ConfigureAwait(false);
        }

        public GreenCollegeDbContext dbContext => _context as GreenCollegeDbContext;
    }
}
