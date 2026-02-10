using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using UniversityManagementMvc.Models;

namespace UniversityManagementMvc.Controllers
{
    public class InstructorController : Controller
    {
        private readonly HttpClient _client;

        public InstructorController(IHttpClientFactory httpFactory)
        {
            _client = httpFactory.CreateClient("BackendApi");
        }

        
        public async Task<IActionResult> Index()
        {
            var result = await _client.GetFromJsonAsync<List<Instructor>>("Instructor");
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _client.GetFromJsonAsync<Instructor>($"Instructor/{id}");
            if (result == null) return NotFound();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            var response = await _client.PostAsJsonAsync("Instructor", instructor);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to create Instructor");
            return View(instructor);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _client.GetFromJsonAsync<Instructor>($"Instructor/{id}");
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Instructor instructor)
        {
            var response = await _client.PutAsJsonAsync("Instructor", instructor);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Update failed");
            return View(instructor);
        }


        public async Task<IActionResult> Delete(string id)
        {
            await _client.DeleteAsync($"Instructor/{id}");
            return RedirectToAction("Index");
        }
    }
}
