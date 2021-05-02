using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaBox.Client.Controllers
{
    public class ConsumerController : Controller
    {
        public string url = "https://localhost:5001/api/";

        public static Order _order { get; set; }

        public static List<Customer> Customers { get; set; }
        public static List<Store> Stores { get; set; }
        public static List<Topping> Toppings { get; set; }
        public static List<PizzaSize> PizzaSizes { get; set; }
        public static List<Crust> Crusts { get; set; }

        public ConsumerController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            _order = new Order();
            _order.StoreId = 3;
            _order.Cost = 0;

            // Customers
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Customer");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Customer>>();
                    readTask.Wait();
                    Customers = readTask.Result;
                }
            }

            // Stores
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
            }

            // PizzaSizes
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("PizzaSize");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PizzaSize>>();
                    readTask.Wait();
                    PizzaSizes = readTask.Result;
                }
            }

            // Crusts
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Crust");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Crust>>();
                    readTask.Wait();
                    Crusts = readTask.Result;
                }
            }

            // Toppings
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Topping");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Topping>>();
                    readTask.Wait();
                    Toppings = readTask.Result;
                }
            }

            return View(Customers);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult GetCustomer()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DisplayCustomer(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Customer/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Customer>();
                    readTask.Wait();
                    _order.Customer = readTask.Result;
                    _order.CustomerId = _order.Customer.CustomerId;
                }
            }

            /*
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Order");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Order>>();
                    readTask.Wait();
                    var orders = readTask.Result;
                    if (orders != null)
                    {
                        foreach (Order order in orders)
                        {
                            if (order.CustomerId == id)
                                Orders.Add(order);
                        }
                    }
                }
            }*/

            return View(_order.Customer.Orders);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        public IActionResult Add1()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal) 13.74;

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 13;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 14;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 15;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 16;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 17;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(pizza);
            _order.Cost += pizza.PizzaPrice;
            return View("AddOrder");
        }

        public IActionResult Add2()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal)11.49;

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 19;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 8;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(pizza);
            _order.Cost += pizza.PizzaPrice;
            return View("AddOrder");
        }

        public IActionResult Add3()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal)13.74;

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 4;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 5;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 6;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 7;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 8;
            pizzaTopping.ToppingCount = 1;
            pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(pizza);
            _order.Cost += pizza.PizzaPrice;
            return View("AddOrder");
        }

        public ActionResult AddStore()
        {
            return View();
        }

        public ActionResult Finish()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                _order.OrderDate = DateTime.Now;
                var postTask = client.PostAsJsonAsync<Order>("Order", _order);
                postTask.Wait();

                var result = postTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PizzaTopping for assistance");
                }
            }
            return View("AddOrder");
        }
    }
}
