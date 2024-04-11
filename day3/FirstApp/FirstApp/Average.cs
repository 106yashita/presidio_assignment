using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Average
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the numbers:");
            int sum = 0,count=0;
            while (true)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= 0)
                {
                    if (num % 7 == 0)
                    {
                        sum += num;
                        count++;
                    }
                }
                else
                {
                    break;
                }
            }
            int average = sum / count;
            Console.WriteLine($"The average of number that is divisible by 7 is {average}");
        }
    }
}
