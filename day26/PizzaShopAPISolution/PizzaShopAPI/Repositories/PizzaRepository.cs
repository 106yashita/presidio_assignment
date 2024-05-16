using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.models;

namespace PizzaShopAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private PizzaShopContext _context;

        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No pizza with the given ID");
        }

        public async Task<Pizza> Get(int key)
        {
            return (await _context.Pizzas.SingleOrDefaultAsync(p => p.pizzaId == key)) ?? throw new Exception("No pizza with the given ID");
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return (await _context.Pizzas.ToListAsync());
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.pizzaId);
            if (pizza != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No pizza with the given ID");
        }
    }
}
