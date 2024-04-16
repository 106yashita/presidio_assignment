using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtClassLibrary
{
    public class Company : GovtRules
    {
        public int Empid { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public int experience { get; set; }

        public Company()
        {
            Empid = 0;
            Name = string.Empty;
            Salary = 0;
            Dept = string.Empty;
            Designation = string.Empty;
            experience = 0;
        }

        public Company(int id, string name, int salary, string dept, string desg, int exp)
        {
            Empid = id;
            Name = name;
            Salary = salary;
            Dept = dept;
            Designation = desg;
            experience=exp;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter Salary");
            Salary = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Department");
            Dept = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Designation");
            Designation = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the experience");
            experience= int.Parse(Console.ReadLine());  

        }

        public  virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Empid);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Employee Salary : " + Salary);
            Console.WriteLine("Employee Department : " + Dept);
            Console.WriteLine("Employee Designation : " + Designation);
            Console.WriteLine("Employee experience : " + experience);
        }

        public virtual double EmployeePF(double basicSalary)
        {
            return 0;
        }

         public virtual double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

         public virtual string LeaVeDetails()
        {
            return "";
        }
    }
}
