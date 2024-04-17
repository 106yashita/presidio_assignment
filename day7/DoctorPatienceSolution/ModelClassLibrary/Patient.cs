using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    public class Patient
    {
        public int PatienceID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;

        public Patient()
        {
            PatienceID = 0;
            Name = string.Empty;
            Age = 0;
            Gender = string.Empty;
            Description = string.Empty;
        }

        public Patient(int patienceID, string name, int age, string gender, string description)
        {
            PatienceID = patienceID;
            Name = name;
            Age = age;
            Gender = gender;
            Description = description;
        }
    }
}
