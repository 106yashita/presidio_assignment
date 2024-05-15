using PizzaShopAPI.models;

namespace PizzaShopAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetPizzas();
    }
}
