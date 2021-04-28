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
            var customers = context.Customers;
            return customers.Select(customer => mapper.Map(customer)).ToList();
        }

        public List<AStore> GetAllStores()
        {
            var stores = context.Stores;
            return stores.Select(store => mapper.Map(store)).ToList();
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
            return mapper.Map(context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
        }

        public AStore GetStore(int id)
        {
            return mapper.Map(context.Stores.Where(x => x.StoreId == id).FirstOrDefault());
        }

        public AOrder GetOrder(int id)
        {
            return mapper.Map(context.Orders.Where(x => x.OrderId == id).FirstOrDefault());
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
            return mapper.Map(context.Pizzas.Where(x => x.PizzaId == id).FirstOrDefault());
        }

        public APizzaTopping GetPizzaTopping(int id)
        {
            return mapper.Map(context.PizzaToppings.Where(x => x.PizzaToppingId == id).FirstOrDefault());
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
        public void AddCustomer(ACustomer customer)
        {
            context.Add(mapper.Map(customer));
            context.SaveChanges();
        }

        public void AddStore(AStore store)
        {
            context.Add(mapper.Map(store));
            context.SaveChanges();
        }

        public void AddOrder(AOrder order)
        {
            context.Add(mapper.Map(order));
            context.SaveChanges();
        }

        public void AddPizzaSize(APizzaSize pizzaSize)
        {
            context.Add(mapper.Map(pizzaSize));
            context.SaveChanges();
        }

        public void AddCrust(ACrust crust)
        {
            context.Add(mapper.Map(crust));
            context.SaveChanges();
        }

        public void AddTopping(ATopping topping)
        {
            context.Add(mapper.Map(topping));
            context.SaveChanges();
        }

        public void AddPizza(APizza pizza)
        {
            context.Add(mapper.Map(pizza));
            context.SaveChanges();
        }

        public void AddPizzaTopping(APizzaTopping pizzaTopping)
        {
            context.Add(mapper.Map(pizzaTopping));
            context.SaveChanges();
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
