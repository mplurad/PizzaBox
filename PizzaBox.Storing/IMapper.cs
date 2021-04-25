using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing
{
  public interface IMapper
  {
    AStore Map(Store store);
    Store Map(AStore store);

    ACustomer Map(Customer customer);
    Customer Map(ACustomer customer);

    ACrust Map(Crust crust);
    Crust Map(ACrust crust);

    AOrder Map(Order order);
    Order Map(AOrder order);

    APizza Map(Pizza pizza);
    Pizza Map(APizza pizza);

    APizzaSize Map(PizzaSize pizzaSize);
    PizzaSize Map(APizzaSize pizzaSize);

    APizzaTopping Map(PizzaTopping pizzaTopping);
    PizzaTopping Map(APizzaTopping pizzaTopping);

    ATopping Map(Topping topping);
    Topping Map(ATopping topping);
  }
}