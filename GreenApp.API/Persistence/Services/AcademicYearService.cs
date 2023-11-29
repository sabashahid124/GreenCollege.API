using AutoMapper;
using GreenCollege.API.DTOs.AcademicYearDtos;
using GreenCollege.API.Interfaces;
using GreenCollege.API.Interfaces.IServices;
using GreenCollege.API.Models;

namespace GreenCollege.API.Persistence.Services
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AcademicYearService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAcademicYearDto>> GetAcademicYearsAsync()
        {
            var academicYears = await _unitOfWork.AcademicYearRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAcademicYearDto>>(academicYears);
        }

        public async Task<GetAcademicYearDto> GetByIdAsync(int id)
        {
            var academicYearId = await _unitOfWork.AcademicYearRepository.GetByIdAsync(id);
            return _mapper.Map<GetAcademicYearDto>(academicYearId);
        }

        //public IEnumerable<GetDegreeDto> GetDegrees()
        //{
        //    var degrees = _unitOfWork.DegreeRepository.GetDegrees();
        //    return _mapper.Map<IEnumerable<GetDegreeDto>>(degrees);
        //}

        public void Add(PostAcademicYearDto academicYearDto)
        {
            var academicyear = _mapper.Map<AcademicYear>(academicYearDto);
            _unitOfWork.AcademicYearRepository.Add(academicyear);
        }
        public void Update(GetAcademicYearDto academicYearDto)
        {
            var academicyear = _mapper.Map<AcademicYear>(academicYearDto);
            _unitOfWork.AcademicYearRepository.Update(academicyear);
        }

        public void Remove(GetAcademicYearDto academicYearDto)
        {
            var academicyear = _mapper.Map<AcademicYear>(academicYearDto);
            _unitOfWork.AcademicYearRepository.Remove(academicyear);
        }

        public async Task Complete() => await _unitOfWork.Complete();

        public void Dispose() => _unitOfWork.Dispose();
    }
}
