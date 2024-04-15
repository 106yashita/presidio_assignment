using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApplication
{
    internal class CowAndBull
    {

        void GetHint(string secret, string guess)
        {
            int[] s = new int[100];
            int[] g = new int[100];
            int bulls = 0, cows = 0;

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    s[secret[i] - '0']++;
                    g[guess[i] - '0']++;
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                cows += Math.Min(s[i], g[i]);
            }

            Console.WriteLine($"cows - {cows} , bulls - {bulls}");
            return;
        }

        void GameStart()
        {
            CowAndBull cowAndBull = new CowAndBull();
            Console.WriteLine("Welcome to the Game");
            Console.WriteLine("Enter the secret word");
            String secret = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Enter the guess word");
                String guess = Console.ReadLine();
                cowAndBull.GetHint(secret, guess);
                if (guess == secret)
                {
                    Console.WriteLine("Game End!!!!!");
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            CowAndBull cowAndBull = new CowAndBull();
            cowAndBull.GameStart();
        }
    }
}
