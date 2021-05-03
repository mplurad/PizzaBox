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
        public static Pizza _pizza { get; set; }

        public static List<Customer> Customers { get; set; }
        public static List<Store> Stores { get; set; }
        public static List<Topping> Toppings { get; set; }
        public static List<PizzaSize> PizzaSizes { get; set; }
        public static List<Crust> Crusts { get; set; }

        public ConsumerController()
        {
        }

        /*************** INITIALIZE EVERYTHING AND DISPLAY CUSTOMERS *****************/

        [HttpGet]
        public IActionResult Index()
        {
            _order = new Order();
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

            return View(_order.Customer.Orders);
        }

        /**************************** BEGIN ORDER ************************************/

        public IActionResult SelectStore()
        {
            return View(Stores);
        }

        public IActionResult AddPizza(int id)
        {
            _order.StoreId = id;
            _pizza = new Pizza();
            _pizza.PizzaPrice = 0;
            return View();
        }

        /***************************** PRESET PIZZAS *********************************/

        public IActionResult Add1()
        {
            _pizza.CrustId = 1;
            _pizza.PizzaSizeId = 3;
            _pizza.PizzaPrice = (decimal) 13.74;

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 13;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 14;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 15;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 16;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 17;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(_pizza);
            _order.Cost += _pizza.PizzaPrice;
            return View("AddPizza");
        }

        public IActionResult Add2()
        {
            _pizza.CrustId = 1;
            _pizza.PizzaSizeId = 3;
            _pizza.PizzaPrice = (decimal)11.49;

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 19;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 8;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(_pizza);
            _order.Cost += _pizza.PizzaPrice;
            return View("AddPizza");
        }

        public IActionResult Add3()
        {
            _pizza.CrustId = 1;
            _pizza.PizzaSizeId = 3;
            _pizza.PizzaPrice = (decimal)13.74;

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 4;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 5;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 6;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 7;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping.ToppingId = 8;
            pizzaTopping.ToppingCount = 1;
            _pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(_pizza);
            _order.Cost += _pizza.PizzaPrice;
            return View("AddPizza");
        }

        /************************** CUSTOM PIZZA ***********************************/
        
        public IActionResult SelectPizzaSize()
        {
            return View();
        }

        public IActionResult SelectCrust(int id)
        {
            _pizza.PizzaSizeId = id;
            _pizza.PizzaPrice += PizzaSizes.Where(ps => ps.PizzaSizeId == id).First().PizzaSizePrice;
            return View();
        }

        public IActionResult SetCrust(int id)
        {
            _pizza.CrustId = id;
            _pizza.PizzaPrice += Crusts.Where(c => c.CrustId == id).First().CrustPrice;
            return View("SelectTopping");
        }

        public IActionResult SelectTopping(int id = 0)
        {
            if (id == 0)
                return View();
            foreach (PizzaTopping pt in _pizza.PizzaToppings)
            {
                if (pt.ToppingId == id)
                {
                    pt.ToppingCount += 1;
                    _pizza.PizzaPrice += pt.Topping.ToppingPrice;
                    return View();
                }
            }

            foreach (Topping t in Toppings)
            {
                if (t.ToppingId == id)
                {
                    _pizza.PizzaPrice += t.ToppingPrice;
                    PizzaTopping pizzaTopping = new PizzaTopping();
                    pizzaTopping.Topping = t;
                    pizzaTopping.ToppingCount = 1;
                    pizzaTopping.ToppingId = id;
                    _pizza.PizzaToppings.Add(pizzaTopping);
                    return View();
                }
            }
            return View();
        }

        public IActionResult FinishPizza()
        {
            _order.Pizzas.Add(_pizza);
            _order.Cost += _pizza.PizzaPrice;
            return View("AddPizza");
        }

        
        /********************************* POST ORDER ****************************/

        public IActionResult Finish()
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
            return View();
        }
    }
}
