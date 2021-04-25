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
    IMapper mapper = new Mapper();
    public Repository(HeroesDbmilesContext context)
    {
      this.context = context;
    }

    // ADD
    public void AddCustomer(ACustomer customer)
    {
      context.Add(mapper.Map(customer));
      context.SaveChanges();
    }

    public void AddOrder(AOrder order)
    {
      context.Add(mapper.Map(order));
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

    // GET
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

    public List<APizza> GetAllPizzas()
    {
      return context.Pizzas.Select(mapper.Map).ToList();
    }

    public List<ACrust> GetAllCrusts()
    {
      return context.Crusts.Select(mapper.Map).ToList();
    }
    public ACrust GetCrust(int Id)
    {
      return mapper.Map(context.Crusts.Where(crust => crust.CrustId == Id).FirstOrDefault());
    }

    public List<APizzaSize> GetAllPizzaSizes()
    {
      return context.PizzaSizes.Select(mapper.Map).ToList();
    }

    public List<ATopping> GetAllToppings()
    {
      return context.Toppings.Select(mapper.Map).ToList();
    }

    public List<APizzaTopping> GetAllPizzaToppings()
    {
      return context.PizzaToppings.Select(mapper.Map).ToList();
    }

    // UPDATE
    public void Update(ACustomer customer)
    {
      var toUpdate = context.Customers.Where(c => c.CustomerId == customer.CustomerId).FirstOrDefault();
      if (toUpdate != null)
      {
        toUpdate.CustomerFirstName = customer.CustomerFirstName;
        toUpdate.CustomerLastName = customer.CustomerLastName;
        toUpdate.CustomerPhone = customer.CustomerPhone;
        toUpdate.Orders = customer.Orders.Select(mapper.Map).ToList();
        toUpdate.Password = customer.Password;
        toUpdate.Username = customer.Username;
        toUpdate.CustomerCardNumber = customer.CustomerCardNumber;
        toUpdate.CustomerAddress = customer.CustomerAddress;
        toUpdate.CustomerCardCvv = customer.CustomerCardCvv;
        toUpdate.CustomerCardDate = customer.CustomerCardDate;
        context.SaveChanges();
      }
    }
    public void Update(AStore store)
    {
      var toUpdate = context.Stores.Where(s => s.StoreId == store.StoreId).FirstOrDefault();
      if (toUpdate != null)
      {
        toUpdate.Orders = store.Orders.Select(mapper.Map).ToList();
        toUpdate.StoreLocation = store.StoreLocation;
        context.SaveChanges();
      }
    }
  }
}