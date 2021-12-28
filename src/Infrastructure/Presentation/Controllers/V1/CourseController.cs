using Contracts.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Courses;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCoursesAsync()
        {
            try
            {
                var response = await _courseService.GetAllAsync();
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{courseCode}")]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourseByCode(string courseCode)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _courseService.GetByCodeAsync(courseCode);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)StatusCodes.Status201Created)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStudent([FromBody] CourseForCreationRequest course)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _courseService.CreateAsync(course);
                if (response == null)
                {
                    return BadRequest();
                }
                return Created("Post", response);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{courseCode}")]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudent(string courseCode, [FromBody] CourseForUpdateRequest course)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                course.SetCourseCode(courseCode);
                var response = await _courseService.UpdateAsync(course);
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{courseCode}")]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStudent(string courseCode)
        {
            try
            {
                var response = await _courseService.DeleteAsync(courseCode);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
