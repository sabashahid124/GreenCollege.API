using GreenCollege.API.DTOs.SectionDtos;

namespace GreenCollege.API.Interfaces.IServices
{
    public interface ISectionService
    {
        Task<GetSectionDto> GetByIdAsync(int id);
        Task<IEnumerable<GetSectionDto>> GetSectionsAsync();
        void Add(PostSectionDto sectionDto);
        void Remove(GetSectionDto sectionDto);
        void Update(GetSectionDto sectionDto);
        Task Complete();
        void Dispose();
    }
}
