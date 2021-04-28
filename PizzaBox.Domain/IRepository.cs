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
        ACustomer GetCustomer(int id);
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
        void UpdateOrder(AOrder order);
        void UpdatePizzaSize(APizzaSize pizzaSize);
        void UpdateCrust(ACrust crust);
        void UpdateTopping(ATopping topping);
        void UpdatePizza(APizza pizza);
        void UpdatePizzaTopping(APizzaTopping pizzaTopping);

        // DELETE BY ID
        void DeleteCustomer(int id);
        void DeleteStore(int id);
        void DeleteOrder(int id);
        void DeletePizzaSize(int id);
        void DeleteCrust(int id);
        void DeleteTopping(int id);
        void DeletePizza(int id);
        void DeletePizzaTopping(int id);
    }
}
