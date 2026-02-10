using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using UniversityManagementMvc.Models;

namespace UniversityManagementMvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient _httpClient;

        public StudentController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("BackendApi");
        }

        
        public async Task<IActionResult> Index()
        {
            var students = await _httpClient.GetFromJsonAsync<List<Students>>("Student");
            return View(students ?? new List<Students>());
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var student = await _httpClient.GetFromJsonAsync<Students>($"Student/{id}");
            if (student == null) return NotFound();
            return View(student);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Students student)
        {
            if (!ModelState.IsValid) return View(student);

            var response = await _httpClient.PostAsJsonAsync("Student", student);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));

            // show error
            ModelState.AddModelError(string.Empty, "API returned an error while creating student.");
            return View(student);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _httpClient.GetFromJsonAsync<Students>($"Student/{id}");
            if (student == null) return NotFound();
            return View(student);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Students student)
        {
            if (!ModelState.IsValid) return View(student);

            var response = await _httpClient.PutAsJsonAsync("Student/Update", student);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "API returned an error while updating student.");
            return View(student);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _httpClient.GetFromJsonAsync<Students>($"Student/{id}");
            if (student == null) return NotFound();
            return View(student);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"Student/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "API returned an error while deleting student.");
                var student = await _httpClient.GetFromJsonAsync<Students>($"Student/{id}");
                return View(student);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
