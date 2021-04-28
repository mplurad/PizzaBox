using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using PizzaBox.Client.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaBox.Client.Controllers
{
    public class AdminController : Controller
    {
        public string url = "https://localhost:5001/api/";

        public List<Customer> Customers { get; set; }
        public List<Store> Stores { get; set; }
        public List<Order> Orders { get; set; }
        public List<PizzaSize> PizzaSizes { get; set; }
        public List<Crust> Crusts { get; set; }
        public List<Topping> Toppings { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<PizzaTopping> PizzaToppings { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllCustomers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Customer"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Customer>>();
                    readTask.Wait();
                    Customers = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Customers);
        }

        [HttpGet]
        public IActionResult AllStores()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Store");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Store>>();
                    readTask.Wait();
                    Stores = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Stores);
        }

        [HttpGet]
        public IActionResult AllOrders()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Customer"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Order>>();
                    readTask.Wait();
                    Orders = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Orders);
        }

        [HttpGet]
        public IActionResult AllPizzaSizes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("PizzaSize"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PizzaSize>>();
                    readTask.Wait();
                    PizzaSizes = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(PizzaSizes);
        }

        [HttpGet]
        public IActionResult AllCrusts()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Crust"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Crust>>();
                    readTask.Wait();
                    Crusts = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Crusts);
        }

        [HttpGet]
        public IActionResult AllToppings()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Topping"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Topping>>();
                    readTask.Wait();
                    Toppings = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Toppings);
        }

        [HttpGet]
        public IActionResult AllPizzas()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Pizza"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Pizza>>();
                    readTask.Wait();
                    Pizzas = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PIZZA for assistance");
                }
            }
            return View(Pizzas);
        }

        [HttpGet]
        public IActionResult AllPizzaToppings()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("PizzaTopping"); // HTTP GET
                responseTask.Wait();

                var result = responseTask.Result; // This holds the output

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PizzaTopping>>();
                    readTask.Wait();
                    PizzaToppings = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PizzaTopping for assistance");
                }
            }
            return View(PizzaToppings);
        }
    }
}
