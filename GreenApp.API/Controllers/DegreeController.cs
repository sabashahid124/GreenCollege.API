using GreenCollege.API.DTOs.DegreeDtos;
using GreenCollege.API.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GreenCollege.API.Controllers
{
    [Route("api/degree")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _degreeService;

        public DegreeController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        // GET: api/degrees
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllDegrees()
        {
            var degrees = await _degreeService.GetAllDegreesAsync();
            return Ok(degrees);
        }

        // GET: api/degrees/1
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetDegreeById(int id)
        {
            var degreeId = await _degreeService.GetDegreeByIdAsync(id);
            if (degreeId == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(degreeId);
        }

        // Post: api/degrees/create
        [HttpPost("create")]
        [ProducesResponseType(200)]

        public async Task<IActionResult> AddDegree(PostDegreeDto degreeDto)
        {
            if (ModelState.IsValid)
            {
                _degreeService.Add(degreeDto);
                await _degreeService.Complete();
                return Ok(degreeDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // Put: api/degrees/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateDegree(GetDegreeDto degreeDto)
        {
            if (degreeDto == null)
            {
                return NotFound();
            }
            try
            {
                _degreeService.Update(degreeDto);
                await _degreeService.Complete();
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating Degree {degreeDto}.");
            }

            return NoContent();
        }

        // Delete: api/degrees/delete
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDegree(GetDegreeDto degreeDto)
        {
            if (degreeDto != null)
            {

                _degreeService.Remove(degreeDto);
                await _degreeService.Complete();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
