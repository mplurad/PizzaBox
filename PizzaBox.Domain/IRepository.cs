using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain
{
    public interface IRepository
    {
        // GET ALL
        List<ACustomer> GetAllCustomers();
        List<AStore> GetAllStores();
        List<AOrder> GetAllOrders();
        List<APizzaSize> GetAllPizzaSizes();
        List<ACrust> GetAllCrusts();
        List<ATopping> GetAllToppings();
        List<APizza> GetAllPizzas();
        List<APizzaTopping> GetAllPizzaToppings();

        // GET BY ID
        ACustomer GetCustomers(int id);
        AStore GetStore(int id);
        AOrder GetOrder(int id);
        APizzaSize GetPizzaSize(int id);
        ACrust GetCrust(int id);
        ATopping GetTopping(int id);
        APizza GetPizza(int id);
        APizzaTopping GetPizzaTopping(int id);

        // POST
        void AddCustomer(ACustomer customer);
        void AddStore(AStore store);
        void AddOrder(AOrder order);
        void AddPizza(APizza pizza);
        void AddPizzaSize(APizzaSize pizzaSize);
        void AddTopping(ATopping topping);
        void AddCrust(ACrust crust);
        void AddPizzaTopping(APizzaTopping pizzaTopping);

        // PUT
        void UpdateCustomer(ACustomer customer);
        void UpdateStore(AStore store);
        void UpdateOrder(ACustomer customer);
        void UpdatePizzaSize(AStore store);
        void UpdateCrust(ACustomer customer);
        void UpdateTopping(AStore store);
        void UpdatePizza(ACustomer customer);
        void UpdatePizzaTopping(AStore store);

        // DELETE BY ID
        void DeleteStore(byte storeID);
    }
}