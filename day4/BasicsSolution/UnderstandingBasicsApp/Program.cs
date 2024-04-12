namespace UnderstandingBasicsApp
{
    internal class Program
    {
        Employee CreateEmployeeByTakingDetailsFromConsole(int id)
        {
            Employee employee = new Employee(id);
            Console.WriteLine("Please enter the emplyee name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Please enterthe employee Date of Birth");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the employee salary");
            double salary;
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            employee.Salary = salary;
            Console.WriteLine("Please enter the employee email");
            employee.Email = Console.ReadLine();
            return employee;
        }

        static void Main(string[] args)
        {
            //Employee employee = new Employee();
            //employee.Name = "Ramu";
            //employee.Salary = 10000;
            //employee.DateOfBirth = new DateTime(2000, 12, 18);
            //employee.Email = "ramu@abccorp.com";
            //Employee employee2 = new Employee
            //{
            //    Name = "Somu",
            //    DateOfBirth = new DateTime(2000, 3, 6),
            //    Email = "somu@abccorp.com",
            //    Salary = 40000
            //};
            //Employee employee3 = new Employee(103, "Bimu", 123423, new DateTime(2000, 05, 07), "bimu@abcorp.com");
            //Console.WriteLine(employee3.Id + " " + employee3.Name);

            //Console.WriteLine(employee2.Salary);
            //employee.Work();

            Program program = new Program();
            Employee[] employees = new Employee[3];
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = program.CreateEmployeeByTakingDetailsFromConsole(101 + i);
            }
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].PrintEmployeeDetails();
            }

        }
    }
}
