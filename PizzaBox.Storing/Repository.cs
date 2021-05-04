using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing
{
    public class Repository : IRepository
    {
        private readonly HeroesDbmilesContext context;
        private readonly IMapper mapper = new Mapper();
        public Repository(HeroesDbmilesContext context)
        {
            this.context = context;
        }

        // GET ALL
        public List<ACustomer> GetAllCustomers()
        {
            return context.Customers.Select(mapper.Map).ToList();
        }

        public List<AStore> GetAllStores()
        {
            return context.Stores.Select(mapper.Map).ToList();
        }

        public List<AOrder> GetAllOrders()
        {
            return context.Orders.Select(mapper.Map).ToList();
        }

        public List<APizzaSize> GetAllPizzaSizes()
        {
            return context.PizzaSizes.Select(mapper.Map).ToList();
        }

        public List<ACrust> GetAllCrusts()
        {
            return context.Crusts.Select(mapper.Map).ToList();
        }

        public List<ATopping> GetAllToppings()
        {
            return context.Toppings.Select(mapper.Map).ToList();
        }

        public List<APizza> GetAllPizzas()
        {
            return context.Pizzas.Select(mapper.Map).ToList();
        }

        public List<APizzaTopping> GetAllPizzaToppings()
        {
            return context.PizzaToppings.Select(mapper.Map).ToList();
        }

        // GET BY ID
        public ACustomer GetCustomer(int id)
        {
            var customer = mapper.Map(context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            customer.Orders = context.Orders.Where(o => o.CustomerId == id).Select(mapper.Map).ToList();
            //customer.Orders.Select(o => o.Pizzas = context.Pizzas.Where(p => p.OrderId == o.OrderId).Select(mapper.Map).ToList());
            //customer.Orders.Select(o => o.Pizzas.Select(p => p.PizzaToppings = context.PizzaToppings.Where(pt => pt.PizzaId == p.PizzaId).Select(mapper.Map).ToList()));
            //customer.Orders.Select(o => o.Pizzas.Select(p => p.PizzaToppings.Select(pt => pt.Topping = mapper.Map(context.Toppings.Find(pt.ToppingId)))));
            return customer;
        }

        public AStore GetStore(int id)
        {
            var store = mapper.Map(context.Stores.Where(x => x.StoreId == id).FirstOrDefault());
            store.Orders = context.Orders.Where(o => o.StoreId == id).Select(mapper.Map).ToList();
            return store;
        }

        public AOrder GetOrder(int id)
        {
            var order = mapper.Map(context.Orders.Where(x => x.OrderId == id).FirstOrDefault());
            order.Pizzas = context.Pizzas.Where(p => p.OrderId == id).Select(mapper.Map).ToList();
            order.Store = GetStore(order.StoreId);
            order.Customer = GetCustomer(order.CustomerId);
            return order;
        }

        public APizzaSize GetPizzaSize(int id)
        {
            return mapper.Map(context.PizzaSizes.Where(x => x.PizzaSizeId == id).FirstOrDefault());
        }

        public ACrust GetCrust(int id)
        {
            return mapper.Map(context.Crusts.Where(x => x.CrustId == id).FirstOrDefault());
        }

        public ATopping GetTopping(int id)
        {
            return mapper.Map(context.Toppings.Where(x => x.ToppingId == id).FirstOrDefault());
        }

        public APizza GetPizza(int id)
        {
            var pizza = mapper.Map(context.Pizzas.Where(x => x.PizzaId == id).FirstOrDefault());
            pizza.Crust = GetCrust(pizza.CrustId);
            pizza.PizzaSize = GetPizzaSize(pizza.PizzaSizeId);
            pizza.Order = GetOrder(pizza.OrderId);
            pizza.PizzaToppings = context.PizzaToppings.Where(pt => pt.PizzaId == id).Select(mapper.Map).ToList();
            foreach (APizzaTopping pt in pizza.PizzaToppings)
            {
                pt.Topping = GetTopping(pt.ToppingId);
            }
            return pizza;
        }

        public APizzaTopping GetPizzaTopping(int id)
        {
            var pizzaTopping = mapper.Map(context.PizzaToppings.Where(x => x.PizzaToppingId == id).FirstOrDefault());
            pizzaTopping.Pizza = GetPizza(pizzaTopping.PizzaId);
            pizzaTopping.Topping = GetTopping(pizzaTopping.ToppingId);
            return pizzaTopping;
        }

        // GET X BY Y
        public List<AOrder> GetOrdersByCustomer(int customerId)
        {
            return context.Orders.Where(o => o.CustomerId == customerId).Select(mapper.Map).ToList();
        }

        public List<AOrder> GetOrdersByStore(int storeId)
        {
            return context.Orders.Where(o => o.StoreId == storeId).Select(mapper.Map).ToList();
        }

        public List<APizza> GetPizzasByOrder(int orderId)
        {
            return context.Pizzas.Where(p => p.OrderId == orderId).Select(mapper.Map).ToList();
        }

        public List<ATopping> GetToppingsByPizza(int pizzaId)
        {
            var pizzaToppings = context.PizzaToppings.Where(pt => pt.PizzaId == pizzaId);
            List<ATopping> toppings = new();
            foreach (PizzaTopping pizzaTopping in pizzaToppings)
            {
                toppings.Add(mapper.Map(context.Toppings.Find(pizzaTopping.ToppingId)));
            }
            return toppings;
        }

        // POST
        public int AddCustomer(ACustomer customer)
        {
            var mapped = mapper.Map(customer);
            context.Add(mapped);
            context.SaveChanges();
            return mapped.CustomerId;
        }

        public int AddStore(AStore store)
        {
            var mappedStore = mapper.Map(store);
            context.Add(mappedStore);
            context.SaveChanges();
            return mappedStore.StoreId;
        }

        public int AddOrder(AOrder order)
        {
            var mappedOrder = mapper.Map(order);
            context.Add(mappedOrder);
            context.SaveChanges();
            return mappedOrder.OrderId;
        }

        public int AddPizzaSize(APizzaSize pizzaSize)
        {
            var mapped = mapper.Map(pizzaSize);
            context.Add(mapped);
            context.SaveChanges();
            return mapped.PizzaSizeId;
        }

        public int AddCrust(ACrust crust)
        {
            var mapped = mapper.Map(crust);
            context.Add(mapped);
            context.SaveChanges();
            return mapped.CrustId;
        }

        public int AddTopping(ATopping topping)
        {
            var mapped = mapper.Map(topping);
            context.Add(mapped);
            context.SaveChanges();
            return mapped.ToppingId;
        }

        public int AddPizza(APizza pizza)
        {
            var mappedPizza = mapper.Map(pizza);
            context.Add(mappedPizza);
            context.SaveChanges();
            return mappedPizza.PizzaId;
        }

        public int AddPizzaTopping(APizzaTopping pizzaTopping)
        {
            var mapped = mapper.Map(pizzaTopping);
            context.Add(mapped);
            context.SaveChanges();
            return mapped.PizzaToppingId;
        }

        // PUT
        public void UpdateCustomer(ACustomer customer)
        {
            var toUpdate = context.Customers.Find(customer.CustomerId);
            if (toUpdate != null)
            {
                toUpdate.CustomerFirstName = customer.CustomerFirstName;
                toUpdate.CustomerLastName = customer.CustomerLastName;
                toUpdate.CustomerPhone = customer.CustomerPhone;
                toUpdate.Password = customer.Password;
                toUpdate.Username = customer.Username;
                toUpdate.CustomerCardNumber = customer.CustomerCardNumber;
                toUpdate.CustomerAddress = customer.CustomerAddress;
                toUpdate.CustomerCardCvv = customer.CustomerCardCvv;
                toUpdate.CustomerCardDate = customer.CustomerCardDate;
                context.SaveChanges();
            }
        }

        public void UpdateStore(AStore newItem)
        {
            var oldItem = context.Stores.Find(newItem.StoreId);
            if (oldItem != null)
            {
                oldItem.StoreId = newItem.StoreId;
                oldItem.StoreLocation = newItem.StoreLocation;
                context.SaveChanges();
            }
        }

        public void UpdateOrder(AOrder newItem)
        {
            var oldItem = context.Orders.Find(newItem.OrderId);
            if (oldItem != null)
            {
                oldItem.Cost = newItem.Cost;
                oldItem.CustomerId = newItem.CustomerId;
                oldItem.OrderDate = newItem.OrderDate;
                oldItem.StoreId = newItem.StoreId;
                context.SaveChanges();
            }
        }

        public void UpdatePizzaSize(APizzaSize newItem)
        {
            var oldItem = context.PizzaSizes.Find(newItem.PizzaSizeId);
            if (oldItem != null)
            {
                oldItem.PizzaSizeInches = newItem.PizzaSizeInches;
                oldItem.PizzaSizeName = newItem.PizzaSizeName;
                oldItem.PizzaSizePrice = newItem.PizzaSizePrice;
                context.SaveChanges();
            }
        }

        public void UpdateCrust(ACrust newItem)
        {
            var oldItem = context.Crusts.Find(newItem.CrustId);
            if (oldItem != null)
            {
                oldItem.CrustName = newItem.CrustName;
                oldItem.CrustPrice = newItem.CrustPrice;
                context.SaveChanges();
            }
        }

        public void UpdateTopping(ATopping newItem)
        {
            var oldItem = context.Toppings.Find(newItem.ToppingId);
            if (oldItem != null)
            {
                oldItem.ToppingName = newItem.ToppingName;
                oldItem.ToppingPrice = newItem.ToppingPrice;
                context.SaveChanges();
            }
        }

        public void UpdatePizza(APizza newItem)
        {
            var oldItem = context.Pizzas.Find(newItem.PizzaId);
            if (oldItem != null)
            {
                oldItem.CrustId = newItem.CrustId;
                oldItem.OrderId = newItem.OrderId;
                oldItem.PizzaPrice = newItem.PizzaPrice;
                oldItem.PizzaSizeId = newItem.PizzaSizeId;
                context.SaveChanges();
            }
        }

        public void UpdatePizzaTopping(APizzaTopping newItem)
        {
            var oldItem = context.PizzaToppings.Find(newItem.PizzaToppingId);
            if (oldItem != null)
            {
                oldItem.PizzaId = newItem.PizzaId;
                oldItem.ToppingCount = newItem.ToppingCount;
                oldItem.ToppingId = newItem.ToppingId;
                context.SaveChanges();
            }
        }

        // DELETE
        public void DeleteCustomer(int id)
        {
            var item = context.Customers.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public void DeleteStore(int id)
        {
            var item = context.Stores.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var item = context.Orders.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public void DeletePizzaSize(int id)
        {
            var item = context.PizzaSizes.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public void DeleteCrust(int id)
        {
            var item = context.Crusts.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public void DeleteTopping(int id)
        {
            var item = context.Toppings.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public void DeletePizza(int id)
        {
            var item = context.Pizzas.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public void DeletePizzaTopping(int id)
        {
            var item = context.PizzaToppings.Find(id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
