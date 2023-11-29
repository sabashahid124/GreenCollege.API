using GreenCollege.API.Data;
using GreenCollege.API.Interfaces.IRepositories;
using GreenCollege.API.Models;

namespace GreenCollege.API.Persistence.Repositories
{
    public class DegreeRepository : Repository<Degree>, IDegreeRepository
    {
        public DegreeRepository(GreenCollegeDbContext _context) : base(_context)
        {
        }

        public IEnumerable<Degree> GetDegrees()
        {
            return dbContext.Degrees.ToList();
        }
        public GreenCollegeDbContext dbContext => _context as GreenCollegeDbContext;
    }
}
