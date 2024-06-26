﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassApp
{
    internal class Student
    {
        public int Id { get; set; }
        string[] skills = new string[3];
        public string Name { get; set; }
        public string this[int index]
        {
            get { return skills[index]; }
            set { skills[index] = value; }
        }
        public override string ToString()
        {
            string data = Id + " " + Name + " ";
            for (int i = 0; i < skills.Length; i++)
                data += skills[i] + " ";
            return data;
        }
    }
}
