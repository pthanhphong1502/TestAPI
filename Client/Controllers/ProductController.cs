using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7066/api/");
        private readonly HttpClient _client;

        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Product/GetAllProducts").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            }
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> SearchProducts(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                // Handle the case where no search query is provided
                return View("SearchResults", new List<ProductViewModel>());
            }

            HttpResponseMessage response = await _client.GetAsync($"Product/SearchProducts?productName={productName}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<ProductViewModel> searchResults = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
                return View("SearchResults", searchResults);
            }
            else
            {
                // Handle the case where the API request fails
                return View("SearchResults", new List<ProductViewModel>());
            }
        }

    }
}
