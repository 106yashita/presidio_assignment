using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.models;

namespace PizzaShopAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            var pizzas = (await _repository.Get()).Where(p => p.availableStock>0).ToList();
            if (pizzas.Count() == 0)
                throw new NoEmployeesFoundException();
            return pizzas;
        }
    }
}
