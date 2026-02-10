using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UniversityManagementMvc.Models;

namespace UniversityManagementMvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HttpClient _client;
        public DepartmentController(IHttpClientFactory httpClientFactory)
            => _client = httpClientFactory.CreateClient("BackendApi");


        public async Task<IActionResult> Index()
        {
            var result = await _client.GetFromJsonAsync<List<Department>>("Department");
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _client.GetFromJsonAsync<Department>($"Department/{id}");
            if (result == null) return NotFound();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            var result = await _client.PostAsJsonAsync("Department", department);
            if(result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Faild to Create Department");
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _client.GetFromJsonAsync<Department>($"Department/{id}");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            var response = await _client.PutAsJsonAsync("Department", department);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Update failed");
            return View(department);
           
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _client.DeleteAsync($"Department/{id}");
            return RedirectToAction("Index");

        }

    }
}
