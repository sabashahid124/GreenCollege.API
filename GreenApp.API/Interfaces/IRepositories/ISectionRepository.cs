using GreenCollege.API.Models;

namespace GreenCollege.API.Interfaces.IRepositories
{
    public interface ISectionRepository : IRepository<Section>
    {
        IEnumerable<Section> GetSections();
        Task<IEnumerable<Section>> GetSectionsAsync();
    }
}
