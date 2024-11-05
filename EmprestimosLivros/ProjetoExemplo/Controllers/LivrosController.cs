using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoExemplo.Models;

namespace ProjetoExemplo.Controllers
{
    public class LivrosController : Controller
    {
        private readonly HttpClient _httpClient;

        public LivrosController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> Index(LivrosViewModel model)
        {
            
            model.Livros = await BuscarLivros(model.Query ?? "livros");
            return View(model);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(new LivrosViewModel());
        }

        public async Task<List<VolumeInfo>> BuscarLivros(string query)
        {
            string url = $"https://www.googleapis.com/books/v1/volumes?q={query}&langRestrict=pt&printType=books&maxResults=5";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao buscar livros da Google Books API");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BooksResponse>(jsonResponse);

            if (result?.Items != null)
            {
                return result.Items.Select(i => i.VolumeInfo).ToList();
            }

            return new List<VolumeInfo>();
        }
    }
}
