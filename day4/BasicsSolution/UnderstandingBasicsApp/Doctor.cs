using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasicsApp
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Age { get; set; }
        public int Experience { get; set; } = 0;
        public string Qualification { get; set; } 
        public string Speciality { get; set; }

        public Doctor(int id) {
             Id = id;
        }

        /// <summary>
        /// Details of Doctor
        /// </summary>
        /// <param name="id"> </param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="experience"></param>
        /// <param name="qualification"></param>
        /// <param name="speciality"></param>
        public Doctor(int id, string name, int age, int experience, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = experience;
            Qualification = qualification;
            Speciality = speciality;
        }

        /// <summary>
        /// Print all details of doctors
        /// </summary>
        public void PrintDoctorsDetails()
        {
            Console.WriteLine($"Doctor Id\t:\t{Id}");
            Console.WriteLine($"Doctor Name\t:\t{Name}");
            Console.WriteLine($"Doctor Age\t:\t{Age}");
            Console.WriteLine($"Doctor Experience\t:\t{Experience}");
            Console.WriteLine($"Doctor Qualification\t:\t{Qualification}");
            Console.WriteLine($"Doctor Speciality\t:\t{Speciality}");
        }

    }
}
