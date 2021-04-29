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

        public static List<Customer> Customers { get; set; }
        public static List<Order> Orders { get; set; }
        public static Customer Customer { get; set; }
        public static Store Store { get; set; }
        public static List<Pizza> Pizzas { get; set; }
        public static List<Store> Stores { get; set; }
        public static List<PizzaTopping> PizzaToppings { get; set; }
        public static List<Topping> Toppings { get; set; }
        public static List<PizzaSize> PizzaSizes { get; set; }
        public static List<Crust> Crusts { get; set; }
        public static decimal Bill { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            Bill = 0;

            Store = new Store();
            Store.StoreId = 3;

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

            // Orders
            Orders = new List<Order>();

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

            // Pizzas
            Pizzas = new List<Pizza>();

            // Pizza Toppings
            PizzaToppings = new List<PizzaTopping>();

            return View();
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
                    Customer = readTask.Result;
                }
            }

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
            }

            return View(Orders);
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
            Pizzas.Add(pizza);
            Bill += pizza.PizzaPrice;
            return View("AddOrder");
        }

        public IActionResult Add2()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal)11.49;
            Pizzas.Add(pizza);
            Bill += pizza.PizzaPrice;
            return View("AddOrder");
        }

        public IActionResult Add3()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal)13.74;
            Pizzas.Add(pizza);
            Bill += pizza.PizzaPrice;
            return View("AddOrder");
        }

        public ActionResult AddStore()
        {
            return View();
        }

        /*public ActionResult Finish()
        {
            Order o = new Order();
            o.Cost = Bill;
            o.CustomerId = Customer.CustomerId;
            o.StoreId = Store.StoreId;
            o.OrderDate = DateTime.Now;
            return Finish(o);
        }*/

        public ActionResult Finish()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                Order o = new Order();
                o.Cost = Bill;
                o.CustomerId = Customer.CustomerId;
                o.StoreId = Store.StoreId;
                o.OrderDate = DateTime.Now;
                var postTask = client.PostAsJsonAsync<Order>("Order", o);
                postTask.Wait();

                var result = postTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please call 123-456-PizzaTopping for assistance");
                }
            }
            return View("Index");
        }
    }
}
