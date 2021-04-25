using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing
{
  public class Mapper : IMapper
  {
    public AStore Map(Store store)
    {
      return new AStore
      {
        StoreId = store.StoreId,
        StoreLocation = store.StoreLocation,
        //Orders = store.Orders.Select(x => Map(x)).ToList()
      };
    }

    public Store Map(AStore store)
    {
      return new Store
      {
        StoreId = store.StoreId,
        StoreLocation = store.StoreLocation,
        //Orders = store.Orders.Select(x => Map(x)).ToList()
      };
    }

    public ACrust Map(Crust crust)
    {
      return new ACrust
      {
        CrustId = crust.CrustId,
        CrustName = crust.CrustName,
        CrustPrice = crust.CrustPrice,
        //Pizzas = crust.Pizzas.Select(x => Map(x)).ToList()
      };
    }

    public Crust Map(ACrust crust)
    {
      return new Crust
      {
        CrustId = crust.CrustId,
        CrustName = crust.CrustName,
        CrustPrice = crust.CrustPrice,
        //Pizzas = crust.Pizzas.Select(x => Map(x)).ToList()
      };
    }

    public ACustomer Map(Customer customer)
    {
      return new ACustomer
      {
        CustomerId = customer.CustomerId,
        Username = customer.Username,
        Password = customer.Password,
        CustomerFirstName = customer.CustomerFirstName,
        CustomerLastName = customer.CustomerLastName,
        CustomerPhone = customer.CustomerPhone,
        CustomerAddress = customer.CustomerAddress,
        CustomerCardNumber = customer.CustomerCardNumber,
        CustomerCardDate = customer.CustomerCardDate,
        CustomerCardCvv = customer.CustomerCardCvv,
        //Orders = customer.Orders.Select(x => Map(x)).ToList()
      };
    }

    public Customer Map(ACustomer customer)
    {
      return new Customer
      {
        CustomerId = customer.CustomerId,
        Username = customer.Username,
        Password = customer.Password,
        CustomerFirstName = customer.CustomerFirstName,
        CustomerLastName = customer.CustomerLastName,
        CustomerPhone = customer.CustomerPhone,
        CustomerAddress = customer.CustomerAddress,
        CustomerCardNumber = customer.CustomerCardNumber,
        CustomerCardDate = customer.CustomerCardDate,
        CustomerCardCvv = customer.CustomerCardCvv,
        //Orders = customer.Orders.Select(x => Map(x)).ToList()
      };
    }

    public AOrder Map(Order order)
    {
      return new AOrder
      {
        OrderId = order.OrderId,
        CustomerId = order.CustomerId,
        StoreId = order.StoreId,
        Cost = order.Cost,
        OrderDate = order.OrderDate,
        //Customer = Map(order.Customer),
        //Store = Map(order.Store),
        //Pizzas = order.Pizzas.Select(x => Map(x)).ToList()
      };
    }

    public Order Map(AOrder order)
    {
      return new Order
      {
        OrderId = order.OrderId,
        CustomerId = order.CustomerId,
        StoreId = order.StoreId,
        Cost = order.Cost,
        OrderDate = order.OrderDate,
        //Customer = Map(order.Customer),
        //Store = Map(order.Store),
        //Pizzas = order.Pizzas.Select(x => Map(x)).ToList()
      };
    }

    public APizza Map(Pizza pizza)
    {
      return new APizza
      {
        PizzaId = pizza.PizzaId,
        OrderId = pizza.OrderId,
        CrustId = pizza.CrustId,
        PizzaSizeId = pizza.PizzaSizeId,
        PizzaPrice = pizza.PizzaPrice,
        //Crust = Map(pizza.Crust),
        //Order = Map(pizza.Order),
        //PizzaSize = Map(pizza.PizzaSize),
        //PizzaToppings = pizza.PizzaToppings.Select(x => Map(x)).ToList()
      };
    }

    public Pizza Map(APizza pizza)
    {
      return new Pizza
      {
        PizzaId = pizza.PizzaId,
        OrderId = pizza.OrderId,
        CrustId = pizza.CrustId,
        PizzaSizeId = pizza.PizzaSizeId,
        PizzaPrice = pizza.PizzaPrice,
        //Crust = Map(pizza.Crust),
        //Order = Map(pizza.Order),
        //PizzaSize = Map(pizza.PizzaSize),
        //PizzaToppings = pizza.PizzaToppings.Select(x => Map(x)).ToList()
      };
    }

    public APizzaSize Map(PizzaSize pizzaSize)
    {
      return new APizzaSize
      {
        PizzaSizeId = pizzaSize.PizzaSizeId,
        PizzaSizeName = pizzaSize.PizzaSizeName,
        PizzaSizeInches = pizzaSize.PizzaSizeInches,
        PizzaSizePrice = pizzaSize.PizzaSizePrice,
        //Pizzas = pizzaSize.Pizzas.Select(x => Map(x)).ToList()
      };
    }

    public PizzaSize Map(APizzaSize pizzaSize)
    {
      return new PizzaSize
      {
        PizzaSizeId = pizzaSize.PizzaSizeId,
        PizzaSizeName = pizzaSize.PizzaSizeName,
        PizzaSizeInches = pizzaSize.PizzaSizeInches,
        PizzaSizePrice = pizzaSize.PizzaSizePrice,
        //Pizzas = pizzaSize.Pizzas.Select(x => Map(x)).ToList()
      };
    }

    public APizzaTopping Map(PizzaTopping pizzaTopping)
    {
      return new APizzaTopping
      {
        PizzaToppingId = pizzaTopping.PizzaToppingId,
        PizzaId = pizzaTopping.PizzaId,
        ToppingId = pizzaTopping.ToppingId,
        ToppingCount = pizzaTopping.ToppingCount,
        //Pizza = Map(pizzaTopping.Pizza),
        //Topping = Map(pizzaTopping.Topping)
      };
    }

    public PizzaTopping Map(APizzaTopping pizzaTopping)
    {
      return new PizzaTopping
      {
        PizzaToppingId = pizzaTopping.PizzaToppingId,
        PizzaId = pizzaTopping.PizzaId,
        ToppingId = pizzaTopping.ToppingId,
        ToppingCount = pizzaTopping.ToppingCount,
        //Pizza = Map(pizzaTopping.Pizza),
        //Topping = Map(pizzaTopping.Topping)
      };
    }

    public ATopping Map(Topping topping)
    {
      return new ATopping
      {
        ToppingId = topping.ToppingId,
        ToppingName = topping.ToppingName,
        ToppingPrice = topping.ToppingPrice,
        //PizzaToppings = topping.PizzaToppings.Select(x => Map(x)).ToList()
      };
    }

    public Topping Map(ATopping topping)
    {
      return new Topping
      {
        ToppingId = topping.ToppingId,
        ToppingName = topping.ToppingName,
        ToppingPrice = topping.ToppingPrice,
        //PizzaToppings = topping.PizzaToppings.Select(x => Map(x)).ToList()
      };
    }
  }
}