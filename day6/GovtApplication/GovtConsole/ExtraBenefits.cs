using GovtClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtConsole
{
    internal class ExtraBenefits
    {
        public void EmployeeBenefits(GovtRules govtRules, double Salary, int experience)
        {
           double EmployeePF = govtRules.EmployeePF(Salary);
            String LeaveDetails = govtRules.LeaVeDetails();
            double GratuityAmount = govtRules.gratuityAmount(experience,Salary);

            Console.WriteLine("Employee PF : " + EmployeePF);
            Console.WriteLine("Employee Leave Details : " + LeaveDetails);
            Console.WriteLine("Employee GratuityAmount : " + GratuityAmount);
        }

    }
}
