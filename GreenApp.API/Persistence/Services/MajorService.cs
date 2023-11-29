using AutoMapper;
using GreenCollege.API.DTOs.MajorDtos;
using GreenCollege.API.Interfaces;
using GreenCollege.API.Interfaces.IServices;
using GreenCollege.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCollege.API.Persistence.Services
{
    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MajorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMajorDto>> GetAllMajorsAsync()
        {
            var majors = await _unitOfWork.MajorRepository.GetMajorsAsync();
            return _mapper.Map<IEnumerable<GetMajorDto>>(majors);
        }

        public async Task<GetMajorDto> GetMajorByIdAsync(int id)
        {
            var majors = await _unitOfWork.MajorRepository.GetByIdAsync(id);
            return _mapper.Map<GetMajorDto>(majors);
        }

        public void Add(PostMajorDto majorDto)
        {
            var major = _mapper.Map<Major>(majorDto);
            _unitOfWork.MajorRepository.Add(major);
        }

        public void Update(GetMajorDto majorDto)
        {
            var major = _mapper.Map<Major>(majorDto);
            _unitOfWork.MajorRepository.Update(major);
        }

        public void Remove(GetMajorDto majorDto)
        {
            var major = _mapper.Map<Major>(majorDto);
            _unitOfWork.MajorRepository.Remove(major);
        }

        public async Task Complete() => await _unitOfWork.Complete();

        public void Dispose() => _unitOfWork.Dispose();

        Task<IEnumerable<GetMajorDto>> IMajorService.GetAllMajorsAsync()
        {
            throw new NotImplementedException();
        }

        Task<GetMajorDto> IMajorService.GetMajorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
