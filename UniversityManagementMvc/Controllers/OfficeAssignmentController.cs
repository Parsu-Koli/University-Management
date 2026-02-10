using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using UniversityManagementMvc.Models;

namespace UniversityManagementMvc.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private readonly HttpClient _httpClient;

        
        public OfficeAssignmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }

        public async Task<IActionResult> Index()
        {
            var data = await _httpClient.GetFromJsonAsync<List<OfficeAssignment>>("OfficeAssignment");
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _httpClient.GetFromJsonAsync<OfficeAssignment>($"OfficeAssignment/{id}");
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(OfficeAssignment office)
        {
            var response = await _httpClient.PostAsJsonAsync("OfficeAssignment", office);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to create office assignment");
            return View(office);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _httpClient.GetFromJsonAsync<OfficeAssignment>($"OfficeAssignment/{id}");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OfficeAssignment office)
        {
            var response = await _httpClient.PutAsJsonAsync("OfficeAssignment", office);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Update failed");
            return View(office);
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            await _httpClient.DeleteAsync($"OfficeAssignment/{id}");
            return RedirectToAction("Index");
        }
    }
}
