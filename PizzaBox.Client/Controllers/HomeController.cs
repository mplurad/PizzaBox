using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
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
            return View();
        }

        public IEnumerable<Store> Stores { get; set; }

        // GET: /<controller>/
        public IActionResult AllStores(string url = "https://localhost:5001/api/")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Store"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Worked!");
                    var readTask = result.Content.ReadAsAsync<Store[]>();
                    readTask.Wait();

               
                    return View(readTask.Result);
                }
                else
                {
                    Console.WriteLine("Failed!");
                    Stores = Enumerable.Empty<Store>();
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Stores);
            //return View();
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
