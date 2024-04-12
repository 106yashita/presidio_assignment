using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasicsApp
{
    internal class Employee
    {
        // int id;
        //public int GetId()
        //{
        //    return id;
        //}
        //public void PutId(int eid)
        //{
        //    id = eid;
        //}
        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        //public int Id
        //{
        //    get => id;
        //    set => id = value;
        //}

        double salary;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return (salary - (salary * 10 / 100));
            }
        }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public Employee() 
        {
            Id = 0;
            Name=string.Empty;
            Salary = 0;
            DateOfBirth = DateTime.MinValue;
            Email = string.Empty;
        }
        public Employee(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Prints all teh details of employee
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee Id\t:\t{Id}");
            Console.WriteLine($"Employee name\t:\t{Name}");
            Console.WriteLine($"Employee Date Of Birth\t:\t{DateOfBirth}");
            Console.WriteLine($"Employee Salary\t:\tRs.{Salary}");
            Console.WriteLine($"Employee Email\t:\t{Email}");
        }

        /// <summary>
        ///  Details of Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="email"></param>
        public Employee(int id, string name, double salary, DateTime dateOfBirth, string email)
        {
            Id = id;
            Name = name;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        public void Work()
        {
            Id = 101;
            Console.WriteLine("Work");
        }
    }
}
