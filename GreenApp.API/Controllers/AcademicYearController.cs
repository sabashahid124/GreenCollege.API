using GreenCollege.API.DTOs.AcademicYearDtos;
using GreenCollege.API.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GreenCollege.API.Controllers
{
    [Route("api/academic-year")]
    [ApiController]
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearService _academicYearService;

        public AcademicYearController(IAcademicYearService academicYearService)
        {
            _academicYearService = academicYearService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetAcademicYearDto>))]
        public async Task<IActionResult> GetAllAcademicYears()
        {
            var academicYears = await _academicYearService.GetAcademicYearsAsync();
            return Ok(academicYears);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAcademcYearById(int id)
        {
            var academicYearId = await _academicYearService.GetByIdAsync(id);
            if (academicYearId == null)
            {
                return NotFound();
            }
            return Ok(academicYearId);
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]

        public async Task<IActionResult> AddAcademicYear(PostAcademicYearDto academicYearDto)
        {
            if (ModelState.IsValid)
            {
                _academicYearService.Add(academicYearDto);
                await _academicYearService.Complete();
                return Ok(academicYearDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDegree(GetAcademicYearDto academicYearDto)
        {
            if (academicYearDto == null)
            {
                return NotFound();
            }
            try
            {
                _academicYearService.Update(academicYearDto);
                await _academicYearService.Complete();
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating Degree {academicYearDto}.");
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAcademicYear(GetAcademicYearDto academicYearDto)
        {
            if (academicYearDto != null)
            {

                _academicYearService.Remove(academicYearDto);
                await _academicYearService.Complete();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
