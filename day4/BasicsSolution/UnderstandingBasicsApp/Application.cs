using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasicsApp
{
    internal class Application
    {
        public Doctor CreateDoctor(int id)
        {
            Doctor doctor = new Doctor(id);
            Console.WriteLine("Please enter the doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the doctor age");
            doctor.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the doctor experience");
            doctor.Experience = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the doctor qualification");
            doctor.Qualification = Console.ReadLine();
            Console.WriteLine("Please enter the doctor specialization");
            doctor.Speciality = Console.ReadLine();
            return doctor;
        }

        static void Main(string[] args)
        {
            Application application = new Application();
            Doctor[] doctors = new Doctor[3];
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = application.CreateDoctor(i + 1);
            }
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i].PrintDoctorsDetails();
            }


            Console.WriteLine("Please enter the speciality:");
            string query = Console.ReadLine();
            for (int i = 0; i < doctors.Length; i++)
            {
                if (doctors[i].Speciality == query)
                {
                    doctors[i].PrintDoctorsDetails();
                }
            }
        }
    }
}
