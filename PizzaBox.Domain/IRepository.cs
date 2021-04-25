using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain
{
  public interface IRepository
  {
    // ADD
    void AddCustomer(ACustomer customer);
    void AddOrder(AOrder order);
    void AddPizza(APizza pizza);
    void AddPizzaTopping(APizzaTopping pizzaTopping);

    // GET
    List<ACustomer> GetAllCustomers();
    List<AStore> GetAllStores();
    List<AOrder> GetAllOrders();
    List<APizza> GetAllPizzas();
    List<ACrust> GetAllCrusts();
    ACrust GetCrust(int Id);
    List<APizzaSize> GetAllPizzaSizes();
    List<ATopping> GetAllToppings();
    List<APizzaTopping> GetAllPizzaToppings();

    // UPDATE
    void Update(ACustomer customer);
    void Update(AStore store);
  }
}