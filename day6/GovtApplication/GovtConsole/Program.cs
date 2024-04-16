using GovtClassLibrary;
namespace GovtConsole
{
    public class Program
    {
        Company[] companies;
        public Program()
        {
            companies = new Company[2];
        }

        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("0. Exit");
        }

        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            if (companies[companies.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < companies.Length; i++)
            {
                if (companies[i] == null)
                {
                    companies[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            if (companies[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < companies.Length; i++)
            {
                if (companies[i] != null)
                {
                    PrintEmployee(companies[i]);
                    
                }

            }
        }
        Company CreateEmployee( int id )
        {
            Company company = new Company();
            Console.WriteLine("Enter The Company Name :");
            string name=Console.ReadLine();
            if(name == "ABC")
            {
                company= new ABC();
            }
            else if(name == "XYZ")
            {
                company= new XYZ();
            }
            company.Empid = 101 + id;
            company.BuildEmployeeFromConsole();
            return company;

        }
        void PrintEmployee(Company company)
        {
            Console.WriteLine("---------------------------");
            company.PrintEmployeeDetails();
            ExtraBenefits extraBenefits = new ExtraBenefits();
            extraBenefits.EmployeeBenefits(company, company.Salary, company.experience);
            Console.WriteLine("---------------------------");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}
