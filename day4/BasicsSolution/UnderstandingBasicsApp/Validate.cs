using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UnderstandingBasicsApp
{
    internal class Validate
    {
        int sumOfDigits(int digit)
        {
            int sum = 0;
            while (digit != 0)
            {
                sum += digit % 10;
                digit /= 10;
            }
            return sum;
        }
        bool ValidateCreditCardNumber(string creditCardNumber)
        {
            int sum = 0;
            bool alternate = false;

            for (int i = 0; i < creditCardNumber.Length; i++)
            {
                int digit = int.Parse(creditCardNumber[i].ToString());
                if(alternate) 
                {
                    digit *= 2;
                    while (digit > 9)
                    {
                        digit = sumOfDigits(digit);
                    }
                }
                sum += digit;
                alternate = !alternate;
            }
            return sum % 10 == 0;
        }
       static void Main(string[] args)
        {
            Validate validate = new Validate();
            Console.WriteLine("Please enter your card number:");
            string creditCardNumber=Console.ReadLine();
            string reversedString = new string(creditCardNumber.Reverse().ToArray());
            if (validate.ValidateCreditCardNumber(reversedString))
                Console.WriteLine("Valid credit card number");
            else
                Console.WriteLine("Invalid credit card number");
        }
    }
}
