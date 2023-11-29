using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenCollege.API.Models;
using GreenCollege.API.Interfaces.IRepositories;
using GreenCollege.API.Data;

namespace GreenCollege.API.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(GreenCollegeDbContext _context) : base(_context)
        {
        }

        public IEnumerable<Course> GetCourses()
        {
            return dbContext.Courses
                .Include(c => c.Major)
                .ToList();
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await dbContext.Courses
                .Include(c => c.Major)
                .ToListAsync().ConfigureAwait(false);
        }

        public GreenCollegeDbContext dbContext => _context as GreenCollegeDbContext;
    }
}
