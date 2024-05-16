using PizzaShopAPI.models.DTOs;
using PizzaShopAPI.models;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
