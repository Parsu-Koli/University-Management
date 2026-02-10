using Microsoft.AspNetCore.Mvc;
using UniversityManagementMvc.Models;

namespace UniversityManagementMvc.Controllers
{
    public class CourseAssignmentController : Controller
    {
        private readonly HttpClient _client;
        public CourseAssignmentController(IHttpClientFactory factory)
            => _client = factory.CreateClient("BackendApi");


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _client.GetFromJsonAsync<List<CourseAssignment>>("CourseAssignment");
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CourseAssignment());
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _client.GetFromJsonAsync<CourseAssignment>($"CourseAssignment/{id}");
            if (result == null) return NotFound();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseAssignment assignment)
        {
            var result = await _client.PostAsJsonAsync("CourseAssignment", assignment);
            if(result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Faild to Create CourseAssignment");
            return View(assignment);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _client.GetFromJsonAsync<CourseAssignment>($"CourseAssignment/{id}");
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseAssignment assignment)
        {
            var result = await _client.PutAsJsonAsync("CourseAssignment", assignment);

            if ( result.IsSuccessStatusCode )
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Faild to Update");
            return View(assignment);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _client.DeleteAsync($"CourseAssignment/{id}");
            return RedirectToAction("Index");
        }
    }
}
