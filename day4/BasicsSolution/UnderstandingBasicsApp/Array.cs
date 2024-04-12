using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasicsApp
{
    internal class Array
    {

        static void Main(string[] args)
        {
            int[] ages = new int[5];
            ages[0] = 12;
            ages[1] = 13;
            ages[2] = 14;
            ages[3] = 15;
            ages[4] = 16;
            int count = ages.Length - 1;
            do
            {
                Console.WriteLine(ages[count]);
            } while (count-- >= 0);
        }
    }
}
