using Contracts.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Students;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentsAsync()
        {
            try
            {
                var response = await _studentService.GetAllAsync();
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

        [HttpGet("{studentCpf}")]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentByCpfAsync(string studentCpf)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _studentService.GetByCpfAsync(studentCpf);
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
        public async Task<IActionResult> CreateStudentAsync([FromBody] StudentForCreationRequest student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                StudentResponse response = await _studentService.CreateAsync(student);
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

        [HttpPut("{studentCpf}")]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudentAsync(string studentCpf, [FromBody] StudentForUpdateRequest student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                student.SetStudentCpf(studentCpf);
                var response = await _studentService.UpdateAsync(student);
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{studentCpf}")]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        [ProducesResponseType((int)StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStudentAsync(string studentCpf)
        {
            try
            {
                var response = await _studentService.DeleteAsync(studentCpf);
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
