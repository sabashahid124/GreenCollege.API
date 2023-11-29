using GreenCollege.API.DTOs.MajorDtos;
using GreenCollege.API.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GreenCollege.API.Controllers
{
    [Route("api/major")]
    [ApiController]
    public class MajorController : ControllerBase
    {

        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllMajors()
        {
            var majors = await _majorService.GetAllMajorsAsync();
            return Ok(majors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetMajorById(int id)
        {
            var majorId = await _majorService.GetMajorByIdAsync(id);
            if (majorId == null)
            {
                return NotFound();
            }
            return Ok(majorId);
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]

        public async Task<IActionResult> AddMajor(PostMajorDto majorDto)
        {
            if (ModelState.IsValid)
            {
                _majorService.Add(majorDto);
                await _majorService.Complete();
                return Ok(majorDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMajor(GetMajorDto majorDto)
        {
            if (majorDto == null)
            {
                return NotFound();
            }
            try
            {
                _majorService.Update(majorDto);
                await _majorService.Complete();
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating Degree {majorDto}.");
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMajor(GetMajorDto majorDto)
        {
            if (majorDto != null)
            {

                _majorService.Remove(majorDto);
                await _majorService.Complete();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
