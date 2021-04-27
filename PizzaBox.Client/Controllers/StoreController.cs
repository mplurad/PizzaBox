using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaBox.Client.Controllers
{
    public class Store : Controller
    {
        public IEnumerable<Store> Stores { get; set; }

        // GET: /<controller>/
        public IActionResult Index(string url = "https://localhost:5001/api/")
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

                    Stores = readTask.Result;
                }
                else
                {
                    Console.WriteLine("Failed!");
                    Stores = Enumerable.Empty<Store>();
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Stores);
        }
    }
}
