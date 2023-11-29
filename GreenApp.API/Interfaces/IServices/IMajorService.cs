using GreenCollege.API.DTOs.MajorDtos;

namespace GreenCollege.API.Interfaces.IServices
{
    public interface IMajorService
    {
        Task<IEnumerable<GetMajorDto>> GetAllMajorsAsync();
        Task<GetMajorDto> GetMajorByIdAsync(int id);
        void Add(PostMajorDto majorDto);
        void Update(GetMajorDto majorDto);
        void Remove(GetMajorDto majorDto);
        Task Complete();
        void Dispose();
    }
}
