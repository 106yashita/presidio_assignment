using PizzaShopAPI.models.DTOs;
using PizzaShopAPI.models;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserService
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
