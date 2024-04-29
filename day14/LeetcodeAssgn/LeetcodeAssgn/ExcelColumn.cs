using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeAssgn
{
    public class ExcelColumn
    {
        public async Task<string> ConvertToTitleAsync(int columnNumber)
        { 
            string result = string.Empty;
            while (columnNumber > 0)
            {
                result = (char)('A' + (columnNumber - 1) % 26) + result;
                columnNumber = (columnNumber - 1) / 26;
            }
            return result;
        }

        static void Main(string[] args)
        {
            ExcelColumn column = new ExcelColumn();
            Console.WriteLine("Enter the column number:");
            int columnNumber = int.Parse(Console.ReadLine());
            string title =  column.ConvertToTitleAsync(columnNumber).Result;
            Console.WriteLine("Corresponding column title is " + title);
        }
    }
}
