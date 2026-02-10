using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UniversityManagementMvc.Models;

namespace UniversityManagementMvc.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly HttpClient _client;

        public EnrollmentController(IHttpClientFactory httpFactory)
            => _client = httpFactory.CreateClient("BackendApi");

        public async Task<IActionResult> Index()
        {
            var result = await _client.GetFromJsonAsync<List<Enrollment>>("Enrollment");
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _client.GetFromJsonAsync<Enrollment>($"Enrollment/{id}");
            if (result == null) return NotFound();

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            var result = await _client.PostAsJsonAsync("Enrollment", enrollment);
            if(result.IsSuccessStatusCode )
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to create Instructor");
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _client.GetFromJsonAsync<Enrollment>($"Enrollment/{id}");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Enrollment enrollment)
        {
            var response = await _client.PutAsJsonAsync("Enrollment", enrollment);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Update failed");
            return View(enrollment);
        }


        public async Task<IActionResult> Delete(string id)
        {
            await _client.DeleteAsync($"Enrollment/{id}");
            return RedirectToAction("Index");
        }
    }
}
