using Microsoft.EntityFrameworkCore;
using System.Linq;
using UnderstandingLINQApp.Model;

namespace UnderstandingLINQApp
{
    internal class Program
    {

        void PrintOrderSales()
        {
            pubsContext context = new pubsContext();
            var orders = context.Sales.GroupBy(s => s.TitleId, s => s, (titleId, sales) => new {
                TitleId = titleId,
                Sales = sales.ToList()
            }).ToList();
            foreach (var order in orders)
            {
                Console.WriteLine("Title is");
                Console.WriteLine(order.TitleId);

                Console.WriteLine("Order details are ");
                foreach (var item in order.Sales)
                {
                    Console.WriteLine(item.OrdNum);
                    Console.WriteLine(item.Qty);
                }
            }
        }

        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
            }
        }
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintOrderSales();
        }
    }
}
// Scaffold-DbContext "data source=DB66JX3\DEMOINSTANCE;Integrated security=true;Initial Catalog=pubs;"Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model