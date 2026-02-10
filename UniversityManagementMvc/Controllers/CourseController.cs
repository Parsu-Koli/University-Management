using Microsoft.AspNetCore.Mvc;
using UniversityManagementMvc.Models;

namespace UniversityManagementMvc.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client;
        public CourseController(IHttpClientFactory httpFactory)
        {
            _client = httpFactory.CreateClient("BackendApi");
        }

        public async Task<IActionResult> Index()
        {
            var result = await _client.GetFromJsonAsync<List<Course>>("Course");
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _client.GetFromJsonAsync<Course>($"Course/{id}");
            if(result== null) return NotFound();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            var result = await _client.PostAsJsonAsync("Course", course);
            if(result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Faild to Course Create");
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _client.GetFromJsonAsync<Course>($"Course/{id}");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            var result = await _client.PutAsJsonAsync("Course", course);
            if(result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Faild to Update");
            return View(result);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _client.DeleteAsync($"Course/{id}");
            return RedirectToAction("Index");
        }
    }
}
