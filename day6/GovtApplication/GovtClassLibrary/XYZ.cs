using System.ComponentModel;

namespace GovtClassLibrary
{
    public class XYZ : Company
    {
        //empid,name,dept,desg and basic salary
        public int Empid { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }

        public int experience { get; set; }

        public XYZ()
        {
            Empid = 0;
            Name = string.Empty;
            Salary = 0;
            Dept = string.Empty;
            Designation = string.Empty;
            experience = 0;
        }

        public XYZ(int id, string name, int salary, string dept, string desg, int exp)
        {
            Empid = id;
            Name = name;
            Salary = salary;
            Dept = dept;
            Designation = desg;
            experience = exp;
        }
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
        }

        public override void PrintEmployeeDetails()
        {
            Console.WriteLine(" Company name : XYZ");
            base.PrintEmployeeDetails();
        }

        public override double EmployeePF(double basicSalary)
        {
            double  PF = basicSalary * (0.12);
            return PF;

        }

        public override string LeaVeDetails()
        {
            return "2 day of Casual Leave per month" +
                "\n5 days of Sick Leave per year" +
                "\n5 days of Privilege Leave per year";
        }

        public override double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;

        }
    }
}
