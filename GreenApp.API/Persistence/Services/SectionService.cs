using AutoMapper;
using GreenCollege.API.DTOs.SectionDtos;
using GreenCollege.API.Interfaces;
using GreenCollege.API.Interfaces.IServices;
using GreenCollege.API.Models;

namespace GreenCollege.API.Persistence.Services
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetSectionDto>> GetSectionsAsync()
        {
            var sections = await _unitOfWork.SectionRepository.GetSectionsAsync();
            return _mapper.Map<IEnumerable<GetSectionDto>>(sections);
        }

        public async Task<GetSectionDto> GetSectionByIdAsync(int id)
        {
            var sectionId = await _unitOfWork.SectionRepository.GetByIdAsync(id);
            return _mapper.Map<GetSectionDto>(sectionId);
        }

        public void Add(PostSectionDto sectionDto)
        {
            var section = _mapper.Map<Section>(sectionDto);
            _unitOfWork.SectionRepository.Add(section);
        }

        public void Update(GetSectionDto sectionDto)
        {
            var section = _mapper.Map<Section>(sectionDto);
            _unitOfWork.SectionRepository.Update(section);
        }

        public void Remove(GetSectionDto sectionDto)
        {
            var section = _mapper.Map<Section>(sectionDto);
            _unitOfWork.SectionRepository.Remove(section);
        }

        public async Task Complete() => await _unitOfWork.Complete();

        public void Dispose() => _unitOfWork.Dispose();

        public Task<GetSectionDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
