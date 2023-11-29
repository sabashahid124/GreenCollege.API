using GreenCollege.API.Models;

namespace GreenCollege.API.Interfaces.IRepositories
{
    public interface IAcademicYearRepository : IRepository<AcademicYear>
    {
        IEnumerable<AcademicYear> GetAcademicYears();
    }
}
