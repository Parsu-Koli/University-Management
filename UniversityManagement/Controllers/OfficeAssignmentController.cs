using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeAssignmentController : ControllerBase
    {
        private readonly OfficeAssignmentServices _services;
        public OfficeAssignmentController(OfficeAssignmentServices services)
            => _services = services;

        [HttpGet]
        public async Task<IActionResult> GetOfficeAssignment()
        {
            var result = await _services.GetOfficeAssignment();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddOfficeAssignment(OfficeAssignment officeAssignment)
        {
            var result = await _services.AddOfficeAssignment(officeAssignment);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfficeById(int id)
        {
            var result = await _services.GetOfficeAssById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfficeRepository(OfficeAssignment officeAssignment)
        {
            var result = await _services.UpdateOfficeAssignment(officeAssignment);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeAssignment(int id)
        {
            var result = await _services.DeleteOfficeAssignment(id);
            return Ok(result);
        }
    }
}
