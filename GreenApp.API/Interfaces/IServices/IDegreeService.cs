using GreenCollege.API.DTOs.DegreeDtos;

namespace GreenCollege.API.Interfaces.IServices
{
    public interface IDegreeService
    {
        Task<IEnumerable<GetDegreeDto>> GetAllDegreesAsync();
        Task<GetDegreeDto> GetDegreeByIdAsync(int id);
        void Add(PostDegreeDto degreeDto);
        void Update(GetDegreeDto degreeDto);
        void Remove(GetDegreeDto degreeDto);
        Task Complete();
        void Dispose();
    }
}
