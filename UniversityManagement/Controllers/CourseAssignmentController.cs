using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAssignmentController : Controller
    {
        private readonly CourseAssignmentServices _services;
        public CourseAssignmentController(CourseAssignmentServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAllCourseAssignmentAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddCourseAssignment(CourseAssignment course)
        {
            var post= await _services.AddCourseAssignment(course);
            return Ok(post);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoursebyId(int id)
        {
            var result = await _services.CourseAssignmentByID(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseAssignment course)
        {
            var result = await _services.UpdateCourseAssigment(course);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _services.DeleteCourseAssignment(id);
            return Ok(result);
        }

    }
}
