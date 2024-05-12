using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _employeeRepository = repo;
        }

        public async Task<Employee> Login(Employee employee)
        {
            var emp = await _employeeRepository.Get(employee.Id);
            if (emp != null)
            {
                if (emp.Password == employee.Password)
                    return emp;
            }
            return emp;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var result = await _employeeRepository.Add(employee);
            return result;
        }
    }
}
