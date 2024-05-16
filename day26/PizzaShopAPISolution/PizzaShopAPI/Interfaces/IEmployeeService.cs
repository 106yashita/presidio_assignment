using PizzaShopAPI.models;

namespace PizzaShopAPI.Interfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetEmployees();
    }
}
