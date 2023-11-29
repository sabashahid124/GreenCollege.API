using GreenCollege.API.DTOs.SectionDtos;
using GreenCollege.API.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GreenCollege.API.Controllers
{
    [Route("api/section")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetSections()
        {
            var courses = await _sectionService.GetSectionsAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetSectioneById(int id)
        {
            var sectionId = await _sectionService.GetByIdAsync(id);
            if (sectionId == null)
            {
                return NotFound();
            }
            return Ok(sectionId);
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]

        public async Task<IActionResult> AddSection(PostSectionDto sectionDto)
        {
            if (ModelState.IsValid)
            {
                _sectionService.Add(sectionDto);
                await _sectionService.Complete();
                return Ok(sectionDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSection(GetSectionDto sectionDto)
        {
            if (sectionDto == null)
            {
                return NotFound();
            }
            try
            {
                _sectionService.Update(sectionDto);
                await _sectionService.Complete();
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating Degree {sectionDto}.");
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSection(GetSectionDto sectionDto)
        {
            if (sectionDto != null)
            {

                _sectionService.Remove(sectionDto);
                await _sectionService.Complete();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}