using GreenCollege.API.Models;

namespace GreenCollege.API.Interfaces.IRepositories
{
    public interface IDegreeRepository : IRepository<Degree>
    {
        IEnumerable<Degree> GetDegrees();
    }
}
