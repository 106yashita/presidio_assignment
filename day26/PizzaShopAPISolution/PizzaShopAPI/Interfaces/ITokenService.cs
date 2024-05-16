using PizzaShopAPI.models;

namespace PizzaShopAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
