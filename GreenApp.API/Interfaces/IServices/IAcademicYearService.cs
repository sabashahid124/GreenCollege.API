using GreenCollege.API.DTOs.AcademicYearDtos;

namespace GreenCollege.API.Interfaces.IServices
{
    public interface IAcademicYearService
    {
        Task<IEnumerable<GetAcademicYearDto>> GetAcademicYearsAsync();
        Task<GetAcademicYearDto> GetByIdAsync(int id);
        //IEnumerable<GetDegreeDto> GetDegrees();
        void Add(PostAcademicYearDto academicYearDto);
        void Update(GetAcademicYearDto academicYearDto);
        void Remove(GetAcademicYearDto academicYearDto);
        Task Complete();
        void Dispose();
    }
}
