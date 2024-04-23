using RequestModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestBLLibrary
{
    internal interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);

        Department GetDepartmentByEmpId(int id);

        Employee UpdateEmpName(string EmployeeOldName, string EmployeeNewName);
        string GetEmployeeName(int id);
        string GetEmployeeType(string Name);
        string GetEmployeeRole(string Name);
        Employee DeleteEmployeeById(int id);

        List<Employee> GetAllEmployees();
        List<Employee> GetEmployeesByEmployeeType(string type);
        List<Employee> GetEmployeesByEmployeeRole(string role);

    }
}
