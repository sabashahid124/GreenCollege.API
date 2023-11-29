using GreenCollege.API.Models;

namespace GreenCollege.API.Interfaces.IRepositories
{
    public interface IMajorRepository : IRepository<Major>
    {
        IEnumerable<Major> GetMajors();
        Task<IEnumerable<Major>> GetMajorsAsync();
    }
}
