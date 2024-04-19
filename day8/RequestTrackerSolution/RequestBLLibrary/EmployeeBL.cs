using RequestDALLibrary;
using RequestModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RequestBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateEmployeeNameException();
        }

        public Employee DeleteEmployeeById(int id)
        {
            Employee employee = _employeeRepository.Delete(id);
            if(employee != null)
            {  return employee; }
            throw new EmployeeNotExistException();
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Department GetDepartmentByEmpId(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if(employee!=null)
            {
                return employee.EmployeeDepartment;
            }
            throw new EmployeeNotExistException();
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return employee;
            }
            throw new EmployeeNotExistException();
        }

        public string GetEmployeeName(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return employee.Name;
            }
            throw new EmployeeNotExistException();
        }

        public string GetEmployeeRole(string Name)
        {
            List<Employee> employees = _employeeRepository.GetAll();
            foreach(Employee employee in employees)
            {
                if(employee.Name == Name) return employee.Role;
            }
            throw new EmployeeNotExistException();
        }

        public List<Employee> GetEmployeesByEmployeeRole(string role)
        {
            List<Employee> employeeRole = new List<Employee>();
            List<Employee> employees = _employeeRepository.GetAll();
            foreach (Employee employee in employees) 
            {
                if(employee.Role == role)
                {
                    employeeRole.Add(employee);
                }
            }
            return employeeRole;
        }

        public List<Employee> GetEmployeesByEmployeeType(string type)
        {
            List<Employee> employeeType = new List<Employee>();
            List<Employee> employees = _employeeRepository.GetAll();
            foreach (Employee employee in employees)
            {
                if (employee.Type == type)
                {
                    employeeType.Add(employee);
                }
            }
            return employeeType;
        }

        public string GetEmployeeType(string Name)
        {
            List<Employee> employees = _employeeRepository.GetAll();
            foreach (Employee employee in employees)
            {
                if (employee.Name == Name) return employee.Type;
            }
            throw new EmployeeNotExistException();
        }

        public Employee UpdateEmpName(string EmployeeOldName, string EmployeeNewName)
        {
            List<Employee> employees = _employeeRepository.GetAll();
            foreach (Employee employee in employees)
            {
                if (employee.Name == EmployeeOldName)
                {
                    employee.Name = EmployeeNewName;
                    return employee;
                }
            }
            throw new EmployeeNotExistException();
        }
    }
}
