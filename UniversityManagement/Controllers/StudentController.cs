using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentServices _services;
        public StudentController(StudentServices services)
            => _services = services;

        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var result = await _services.GetStudents();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var result = await _services.AddStudent(student);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _services.GetStudentById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var result = await _services.UpdateStudent(student);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _services.DeleteStudent(id);
            return Ok(result);
        }
    }
}
