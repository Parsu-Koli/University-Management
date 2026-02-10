using BLL.Services;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly DepartmentServices _services;
        public DepartmentController (DepartmentServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            var department = await _services.GetDepartment();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            var result = await _services.AddDepartment(department);
            return Ok(result);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await _services.GetDepartmentById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            var result = await _services.UpdateDepartment(department);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _services.DeleteDepartment(id);
            return Ok(result);
        }

    }
}
