using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FirstApp
{
    internal class Greatest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the numbers:");
            int greatest = int.MinValue;
            while (true) 
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= 0) {
                    greatest = Math.Max(greatest, num);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"The greatest number is {greatest}");
        }
    }
}
