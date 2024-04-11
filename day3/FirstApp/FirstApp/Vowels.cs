using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Vowels
    {
        static string LeastVowel(string[] words)
        {
            int mini = int.MaxValue;
            string ans="";
            foreach (string word in words)
            {
                int count = 0;
                foreach (char c in word)
                {
                    if ("aeiou".Contains(c) || "AEIOU".Contains(c))
                    {
                        count++;
                    }
                }
                if (count < mini)
                {
                    mini = count;
                    ans = word;
                }
            }
            return ans;
        }
        static void RepeatingVowel(string input)
        {
            string vowel = "aeiouAEIOU";
            int mini = int.MaxValue;
            char ans='a';
            foreach (char c  in vowel)
            {
                int count = 0;
                bool flag=false;
                foreach (var item in input)
                {
                    if (c == item)
                    {
                        flag = true;
                        count++;
                    }
                }
                if(count < mini && flag==true)
                {
                    mini=count;
                    ans = c;
                }
            }
            Console.WriteLine($"{ans} comes least time- {mini}");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words seperated with comma(,)");
            string input=Console.ReadLine();
            string[] words = input.Split(',');
            int count=words.Length;
            Console.WriteLine($"Number of words are - {count}");
            string ans=LeastVowel(words);
            Console.WriteLine($"Word that has the least vowels - {ans}");
            RepeatingVowel(input);


        }
    }
}
