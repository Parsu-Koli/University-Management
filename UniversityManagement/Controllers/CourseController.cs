using BLL.Services;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseServices _courseService;

        public CourseController(CourseServices courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(Course course)
        {
            var addcourse = await _courseService.AddCourseAsync(course);
            return Ok(addcourse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoursebyId(int id)
        {
            var result = await _courseService.GetCoursebyId(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            var result = await _courseService.UpdateCourse(course);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourse(id);
            return Ok(result);
        }

    }
}
