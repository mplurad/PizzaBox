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

        public static int _crustId { get; set; }
        public static int _pizzaSizeId { get; set; }
        public static Crust _crust { get; set; }
        public static PizzaSize _pizzaSize { get; set; }
        public static decimal _pizzaPrice { get; set; }
        public static ICollection<PizzaTopping> _PizzaToppings { get; set; }

        public static List<Customer> Customers { get; set; }
        public static List<Store> Stores { get; set; }
        public static List<Topping> Toppings { get; set; }
        public static List<PizzaSize> PizzaSizes { get; set; }
        public static List<Crust> Crusts { get; set; }

        // Display
        public static Order d_order { get; set; }
        public static ICollection<Pizza> d_pizzas { get; set; }
        public static ICollection<PizzaTopping> d_pizzaToppings { get; set; }

        public ConsumerController()
        {
        }

        /*************** INITIALIZE EVERYTHING AND DISPLAY CUSTOMERS *****************/

        [HttpGet]
        public IActionResult Index()
        {
            _order = new Order();
            _order.Cost = 0;
            _PizzaToppings = new HashSet<PizzaTopping>();

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

        [HttpGet]
        public IActionResult DisplayOrder(int id)
        {
            d_order = new Order();
            d_pizzas = new HashSet<Pizza>();
            d_pizzaToppings = new HashSet<PizzaTopping>();

            // Order
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("Order/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Order>();
                    readTask.Wait();
                    d_order = readTask.Result;
                }
            }

            foreach (Pizza pizza in d_order.Pizzas)
            {
                // Pizza
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = client.GetAsync("Pizza/" + pizza.PizzaId.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Pizza>();
                        readTask.Wait();
                        d_pizzas.Add(readTask.Result);
                    }
                }
            }

            //return View(_order.Customer.Orders.Where(o => o.OrderId == id).First());
            return View();
        }

        /**************************** BEGIN ORDER ************************************/

        public IActionResult SelectStore()
        {
            return View(Stores);
        }

        public IActionResult AddPizza(int id)
        {
            _order.StoreId = id;

            _crustId = 0;
            _pizzaSizeId = 0;
            _pizzaPrice = 0;
            _crust = null;
            _pizzaSize = null;
            _PizzaToppings.Clear();

            return View();
        }

        /***************************** PRESET PIZZAS *********************************/

        public IActionResult Add1()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal) 13.74;
            pizza.PizzaSize = PizzaSizes.Where(ps => ps.PizzaSizeId == pizza.PizzaSizeId).First();
            pizza.Crust = Crusts.Where(c => c.CrustId == pizza.CrustId).First();

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 13;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 14;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 15;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 16;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 17;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(pizza);
            _order.Cost += pizza.PizzaPrice;
            return View("AddPizza");
        }

        public IActionResult Add2()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal)11.49;
            pizza.PizzaSize = PizzaSizes.Where(ps => ps.PizzaSizeId == pizza.PizzaSizeId).First();
            pizza.Crust = Crusts.Where(c => c.CrustId == pizza.CrustId).First();

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 19;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 8;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(pizza);
            _order.Cost += pizza.PizzaPrice;
            return View("AddPizza");
        }

        public IActionResult Add3()
        {
            Pizza pizza = new Pizza();
            pizza.CrustId = 1;
            pizza.PizzaSizeId = 3;
            pizza.PizzaPrice = (decimal)13.74;
            pizza.PizzaSize = PizzaSizes.Where(ps => ps.PizzaSizeId == pizza.PizzaSizeId).First();
            pizza.Crust = Crusts.Where(c => c.CrustId == pizza.CrustId).First();

            PizzaTopping pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 4;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 5;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 6;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 7;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            pizzaTopping = new PizzaTopping();
            pizzaTopping.ToppingId = 8;
            pizzaTopping.ToppingCount = 1;
            pizzaTopping.Topping = Toppings.Where(t => t.ToppingId == pizzaTopping.ToppingId).First();
            pizza.PizzaToppings.Add(pizzaTopping);

            _order.Pizzas.Add(pizza);
            _order.Cost += pizza.PizzaPrice;
            return View("AddPizza");
        }

        /************************** CUSTOM PIZZA ***********************************/
        
        public IActionResult SelectPizzaSize()
        {
            return View();
        }

        public IActionResult SelectCrust(int id)
        {
            _pizzaSizeId = id;
            _pizzaSize = PizzaSizes.Where(ps => ps.PizzaSizeId == id).First();
            _pizzaPrice += _pizzaSize.PizzaSizePrice;
            return View();
        }

        public IActionResult SetCrust(int id)
        {
            _crustId = id;
            _crust = Crusts.Where(c => c.CrustId == id).First();
            _pizzaPrice += _crust.CrustPrice;
            return View("SelectTopping");
        }

        public IActionResult SelectTopping(int id = 0)
        {
            if (id == 0)
                return View();
            foreach (PizzaTopping pt in _PizzaToppings)
            {
                if (pt.ToppingId == id)
                {
                    pt.ToppingCount += 1;
                    _pizzaPrice += pt.Topping.ToppingPrice;
                    return View();
                }
            }

            foreach (Topping t in Toppings)
            {
                if (t.ToppingId == id)
                {
                    _pizzaPrice += t.ToppingPrice;
                    PizzaTopping pizzaTopping = new PizzaTopping();
                    pizzaTopping.Topping = t;
                    pizzaTopping.ToppingCount = 1;
                    pizzaTopping.ToppingId = id;
                    _PizzaToppings.Add(pizzaTopping);
                    return View();
                }
            }
            return View();
        }

        public IActionResult FinishPizza()
        {
            Pizza pizza = new Pizza();
            pizza.Crust = _crust;
            pizza.CrustId = _crustId;
            pizza.PizzaPrice = _pizzaPrice;
            pizza.PizzaSize = _pizzaSize;
            pizza.PizzaSizeId = _pizzaSizeId;
            foreach (PizzaTopping pt in _PizzaToppings)
            {
                pizza.PizzaToppings.Add(pt);
            }

            _order.Pizzas.Add(pizza);
            _order.Cost += pizza.PizzaPrice;
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
