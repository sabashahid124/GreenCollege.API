using GreenCollege.API.Data;
using GreenCollege.API.Interfaces.IRepositories;
using GreenCollege.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCollege.API.Persistence.Repositories
{
    internal class MajorRepository : Repository<Major>, IMajorRepository
    {
        public MajorRepository(GreenCollegeDbContext _context) : base(_context)
        {
        }

        public IEnumerable<Major> GetMajors()
        {
            return dbContext.Majors
                .Include(c => c.Degree)
                .ToList();
        }

        public async Task<IEnumerable<Major>> GetMajorsAsync()
        {
            return await dbContext.Majors
                .Include(c => c.Degree)
                .ToListAsync().ConfigureAwait(false);
        }

        public GreenCollegeDbContext dbContext => _context as GreenCollegeDbContext;
    }
}
