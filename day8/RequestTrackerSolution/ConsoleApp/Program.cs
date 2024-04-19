using RequestBLLibrary;
using RequestModelClassLibrary;
namespace ConsoleApp
{
    internal class Program
    {
        void AddEmployee()
        {

            EmployeeBL employeeBL = new EmployeeBL();
            try
            {
                Console.WriteLine("Pleae enter the employee name");
                string name = Console.ReadLine();
                Employee employee = new Employee();
                employee.Name = name;
                employee.Salary = 10;
                employee.DateOfBirth = DateTime.Now;
                employee.EmployeeDepartment = new Department();
                int id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We have created the employee for you and the Id is " + id);
                employee = new Employee();
                employee.Name = "rahul";
                employee.Salary = 10;
                employee.DateOfBirth = DateTime.Now;
                employee.EmployeeDepartment = new Department();
                id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We ahve created the employee for you and the Id is " + id);
                List<Employee> employees = employeeBL.GetAllEmployees();
                foreach (var employee1 in employees)
                {
                    Console.WriteLine(employee1.Name);
                }

            }
            catch (DuplicateEmployeeNameException done)
            {
                Console.WriteLine(done.Message);
            }
        }
        static void Main(string[] args)
        {
            new Program().AddEmployee();
        }
    }
}
