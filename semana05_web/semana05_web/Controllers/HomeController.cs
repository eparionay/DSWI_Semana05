using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using semana05_web.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace semana05_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string url = "https://localhost:44353/api/medico/listado";
            HttpClient cliente = new HttpClient();
            var request = cliente.GetAsync(url).Result;
            var response = new List<Medico>();
            if (request.IsSuccessStatusCode)
            {
               var resultado = request.Content.ReadAsStringAsync().Result;
               response = JsonConvert.DeserializeObject<List<Medico>>(resultado);
            }
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
