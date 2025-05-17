using Baristasyon.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Baristasyon.WebUI.Controllers
{
    public class JobPostController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JobPostController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.GetAsync("jobpost");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultJobPostDto>());

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ResultJobPostDto>>(json);

            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.GetAsync($"jobpost/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResultJobPostDto>(json);

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.GetAsync($"jobpost/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateJobPostDto>(json);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateJobPostDto dto)
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.PutAsJsonAsync($"jobpost/{id}", dto);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Güncelleme başarısız.";
                return View(dto);
            }

            return RedirectToAction("Details", new { id });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobPostDto dto)
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.PostAsJsonAsync("jobpost", dto);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "İlan eklenemedi.";
                return View(dto);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.DeleteAsync($"jobpost/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "İlan silinemedi.";
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Index");
        }




    }
}
