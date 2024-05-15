using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.models;

namespace PizzaShopAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoEmployeesFoundException();
            return employees;
        }
    }
}
