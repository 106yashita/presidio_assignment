using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Name
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name");
            string name=Console.ReadLine();
            int len = name.Length;
            Console.WriteLine("Length of the name is : " + len);

        }
    }
}
