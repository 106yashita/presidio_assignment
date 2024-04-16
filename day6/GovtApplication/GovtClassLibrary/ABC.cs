using System.ComponentModel;

namespace GovtClassLibrary
{
    public class ABC : Company
    {
        //empid,name,dept,desg and basic salary
        public int Empid { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public int experience { get; set; }

        public ABC() {
            Empid = 0;
            Name = string.Empty;
            Salary = 0;
            Dept = string.Empty;
            Designation = string.Empty;
            experience = 0;
        }

        public ABC(int id, string name, int salary, string dept, string desg, int exp)
        {
            Empid = id;
            Name = name;
            Salary=salary;
            Dept = dept;
            Designation = desg;
            experience=exp;
        }

        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
        }

        public  override void PrintEmployeeDetails()
        {
            Console.WriteLine(" Company name : ABC");
            base.PrintEmployeeDetails();
        }


        public override double EmployeePF(double basicSalary)
        {
            double PF = basicSalary * (0.0367);
            return PF;
           
        }

        public override string LeaVeDetails()
        {
            return "1 day of Casual Leave per month" +
                "\n12 days of Sick Leave per year" +
                "\n10 days of Privilege Leave per year";
        }

       

        public override double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            double gratuityAmount = 0;
            if(serviceCompleted > 20) 
            {
                gratuityAmount += basicSalary * (0.03);
            }
            else if (serviceCompleted > 10)
            {
                gratuityAmount += basicSalary * (0.02);
            }
            else if(serviceCompleted > 5)
            {
                gratuityAmount += basicSalary;
            }
            else {
                gratuityAmount = 0;
            }
            return gratuityAmount;

        }
    }
}
