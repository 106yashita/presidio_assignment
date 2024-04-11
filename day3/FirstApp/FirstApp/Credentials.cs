using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Credentials
    {
        static void Main(string[] args)
        {
            int limit = 3;
            while(limit > 0)
            {
                Console.WriteLine("Enter username:");
                string name= Console.ReadLine();
                Console.WriteLine("Enter password:");
                int password=int.Parse(Console.ReadLine());
                if((name=="ABC") && (password==123)) 
                {
                    Console.WriteLine("Welcome");
                    break;
                }
                else
                {
                    limit--;
                    if(limit == 0) {
                        Console.WriteLine("STOP!!!!!!");
                        Console.WriteLine("Sorry! you has exceeded the number of attempts.");
                        break;  
                    }
                    Console.WriteLine("Wrong username and password");
                    Console.WriteLine("Enter Again");
                }
            }

        }
    }
}
