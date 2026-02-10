using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorServices _services;
        public InstructorController(InstructorServices services)
            => _services = services;

        [HttpGet]
        public async Task<IActionResult> GetInstructor()
        {
            var result = await _services.GetInstructor();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructor(Instructor instructor)
        {
            var result = await _services.AddInstructor(instructor);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(int id)
        {
            var result = await _services.GetInstructorById(id);
            if(result == null)           
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInstructor(Instructor instructor)
        {
            var result= await _services.UpdateInstructor(instructor);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var result = await _services.DeleteInstructor(id);
            return Ok(result);
        }
        
    }
}
