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
        /// <summary>
        /// Sum of digits
        /// </summary>
        /// <param name="digit">Greater than 9</param>
        /// <returns></returns>
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
            string reversedString = new string(creditCardNumber.Reverse().ToArray());
            int sum = 0;
            bool alternate = false;

            for (int i = 0; i < reversedString.Length; i++)
            {
                int digit = int.Parse(reversedString[i].ToString());
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
            if (validate.ValidateCreditCardNumber(creditCardNumber) && creditCardNumber.Length == 16)
                Console.WriteLine("Valid credit card number");
            else
                Console.WriteLine("Invalid credit card number");
        }
    }
}
