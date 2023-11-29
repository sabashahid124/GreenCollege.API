using GreenCollege.API.DTOs.CourseDtos;
using GreenCollege.API.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GreenCollege.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var courseId = await _courseService.GetCourseByIdAsync(id);
            if (courseId == null)
            {
                return NotFound();
            }
            return Ok(courseId);
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]

        public async Task<IActionResult> AddDegree(PostCourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                _courseService.Add(courseDto);
                await _courseService.Complete();
                return Ok(courseDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDegree(GetCourseDto courseDto)
        {
            if (courseDto == null)
            {
                return NotFound();
            }
            try
            {
                _courseService.Update(courseDto);
                await _courseService.Complete();
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating Degree {courseDto}.");
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCourse(GetCourseDto courseDto)
        {
            if (courseDto != null)
            {

                _courseService.Remove(courseDto);
                await _courseService.Complete();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
