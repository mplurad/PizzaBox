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
        StoreLocation = store.StoreLocation
      };
    }

    public Store Map(AStore store)
    {
      return new Store
      {
        //StoreId = store.StoreId,
        StoreLocation = store.StoreLocation
      };
    }

    public ACrust Map(Crust crust)
    {
      return new ACrust
      {
        CrustId = crust.CrustId,
        CrustName = crust.CrustName,
        CrustPrice = crust.CrustPrice
      };
    }

    public Crust Map(ACrust crust)
    {
      return new Crust
      {
        CrustId = crust.CrustId,
        CrustName = crust.CrustName,
        CrustPrice = crust.CrustPrice
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
        CustomerCardCvv = customer.CustomerCardCvv
      };
    }

    public Customer Map(ACustomer customer)
    {
      return new Customer
      {
        //CustomerId = customer.CustomerId,
        Username = customer.Username,
        Password = customer.Password,
        CustomerFirstName = customer.CustomerFirstName,
        CustomerLastName = customer.CustomerLastName,
        CustomerPhone = customer.CustomerPhone,
        CustomerAddress = customer.CustomerAddress,
        CustomerCardNumber = customer.CustomerCardNumber,
        CustomerCardDate = customer.CustomerCardDate,
        CustomerCardCvv = customer.CustomerCardCvv
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
        OrderDate = order.OrderDate
      };
    }

    public Order Map(AOrder order)
    {
      return new Order
      {
        //OrderId = order.OrderId,
        CustomerId = order.CustomerId,
        StoreId = order.StoreId,
        Cost = order.Cost,
        OrderDate = order.OrderDate
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
        PizzaPrice = pizza.PizzaPrice
      };
    }

    public Pizza Map(APizza pizza)
    {
      return new Pizza
      {
        //PizzaId = pizza.PizzaId,
        OrderId = pizza.OrderId,
        CrustId = pizza.CrustId,
        PizzaSizeId = pizza.PizzaSizeId,
        PizzaPrice = pizza.PizzaPrice
      };
    }

    public APizzaSize Map(PizzaSize pizzaSize)
    {
      return new APizzaSize
      {
        PizzaSizeId = pizzaSize.PizzaSizeId,
        PizzaSizeName = pizzaSize.PizzaSizeName,
        PizzaSizeInches = pizzaSize.PizzaSizeInches,
        PizzaSizePrice = pizzaSize.PizzaSizePrice
      };
    }

    public PizzaSize Map(APizzaSize pizzaSize)
    {
      return new PizzaSize
      {
        PizzaSizeId = pizzaSize.PizzaSizeId,
        PizzaSizeName = pizzaSize.PizzaSizeName,
        PizzaSizeInches = pizzaSize.PizzaSizeInches,
        PizzaSizePrice = pizzaSize.PizzaSizePrice
      };
    }

    public APizzaTopping Map(PizzaTopping pizzaTopping)
    {
      return new APizzaTopping
      {
        PizzaToppingId = pizzaTopping.PizzaToppingId,
        PizzaId = pizzaTopping.PizzaId,
        ToppingId = pizzaTopping.ToppingId,
        ToppingCount = pizzaTopping.ToppingCount
      };
    }

    public PizzaTopping Map(APizzaTopping pizzaTopping)
    {
      return new PizzaTopping
      {
        //PizzaToppingId = pizzaTopping.PizzaToppingId,
        PizzaId = pizzaTopping.PizzaId,
        ToppingId = pizzaTopping.ToppingId,
        ToppingCount = pizzaTopping.ToppingCount
      };
    }

    public ATopping Map(Topping topping)
    {
      return new ATopping
      {
        ToppingId = topping.ToppingId,
        ToppingName = topping.ToppingName,
        ToppingPrice = topping.ToppingPrice
      };
    }

    public Topping Map(ATopping topping)
    {
      return new Topping
      {
        ToppingId = topping.ToppingId,
        ToppingName = topping.ToppingName,
        ToppingPrice = topping.ToppingPrice
      };
    }
  }
}