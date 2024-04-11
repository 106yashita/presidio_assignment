using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Calculator
    {
        static void Add(int num1, int num2)
        {
            int ans= (num1 + num2);
            PrintResult(ans, "sum");
        }
        static void Subtract(int num1, int num2) 
        {
            int ans = (num2 - num1);
            PrintResult(ans, "subtract");
        }

        static void Multiply(int num1, int num2)
        {
            int ans = (num2*num1);
            PrintResult(ans, "product");
        }
        static void Divide(int num1, int num2)
        {
            int ans= (num2 / num1);
            PrintResult(ans, "divide");
        }
        static void Modulo(int num1, int num2)
        {
            int ans = (num2 % num1);
            PrintResult(ans, "remainder");
        }


        static int TakeNumber()
        {
            int num1;
            Console.WriteLine("Please enter the the number");
            while (int.TryParse(Console.ReadLine(), out num1) == false)
                Console.WriteLine("Invalid input. Please enter a number");
            return num1;
        }

        static void PrintResult(int ans, string ops)
        {
            Console.WriteLine($"The {ops} is {ans}");
        }
        static void Main(string[] args)
        {
            int num1=TakeNumber();
            int num2=TakeNumber();
            Add(num1, num2);
            Subtract(num1, num2);
            Multiply(num1, num2);
            Divide(num1, num2);
            Modulo(num1, num2);

        }

    }
}
