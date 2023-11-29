using AutoMapper;
using GreenCollege.API.DTOs.DegreeDtos;
using GreenCollege.API.Interfaces;
using GreenCollege.API.Interfaces.IServices;
using GreenCollege.API.Models;

namespace GreenCollege.API.Persistence.Services
{
    public class DegreeService : IDegreeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DegreeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDegreeDto>> GetAllDegreesAsync()
        {
            var degrees = await _unitOfWork.DegreeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetDegreeDto>>(degrees);
        }

        public async Task<GetDegreeDto> GetDegreeByIdAsync(int id)
        {
            var degrees = await _unitOfWork.DegreeRepository.GetByIdAsync(id);
            return _mapper.Map<GetDegreeDto>(degrees);
        }

        public void Add(PostDegreeDto degreeDto)
        {
            var degree = _mapper.Map<Degree>(degreeDto);
            _unitOfWork.DegreeRepository.Add(degree);
        }

        public void Update(GetDegreeDto degreeDto)
        {
            var degree = _mapper.Map<Degree>(degreeDto);
            _unitOfWork.DegreeRepository.Update(degree);
        }

        public void Remove(GetDegreeDto degreeDto)
        {
            var degree = _mapper.Map<Degree>(degreeDto);
            _unitOfWork.DegreeRepository.Remove(degree);
        }

        public async Task Complete() => await _unitOfWork.Complete();

        public void Dispose() => _unitOfWork.Dispose();

    }
}
