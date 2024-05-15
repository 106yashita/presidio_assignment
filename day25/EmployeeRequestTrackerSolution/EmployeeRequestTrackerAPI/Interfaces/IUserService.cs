using EmployeeRequestTrackerAPI.models.DTOs;
using EmployeeRequestTrackerAPI.models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
