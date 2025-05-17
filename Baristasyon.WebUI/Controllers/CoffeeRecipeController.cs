using Baristasyon.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Baristasyon.WebUI.Controllers
{
    public class CoffeeRecipeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoffeeRecipeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.GetAsync("coffeerecipe");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultCoffeeRecipeDto>());

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ResultCoffeeRecipeDto>>(json);

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCoffeeRecipeDto dto)
        {
            var client = _httpClientFactory.CreateClient("api");
            var response = await client.PostAsJsonAsync("coffeerecipe", dto);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Tarif eklenemedi.";
                return View(dto);
            }

            return RedirectToAction("Index");
        }

    }
}
