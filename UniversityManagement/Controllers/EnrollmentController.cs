using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentServices _service;
        public EnrollmentController(EnrollmentServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollment()
        {
            var result = await _service.GetEnrollment();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(Enrollment enrollment)
        {
            var result = await _service.AddEnrollment(enrollment);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var result = await _service.GetEnrollmentById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEnrollment(Enrollment enrollment)
        {
            var result = await _service.UpdateEnrollment(enrollment);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErollment(int id)
        {
            var result = await _service.DeleteEnrollment(id);
            return Ok(result);
        }

        
    }
}
