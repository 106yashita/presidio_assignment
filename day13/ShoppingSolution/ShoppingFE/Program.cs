using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingFE
{
    internal class Program
    {

        //    //public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method
        //    //public delegate float calcDelFloat(float n1, float n2);//creating a type that refferes to a method
        //    public delegate T calcDel<T>(T n1, T n2);//creating a generic  type that refferes to a method
        //    void Calculate(Func<int, int, int> cal)
        //    {
        //        int n1 = 10, n2 = 20;
        //        int result = cal(n1, n2);
        //        Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //    }
        //    //public int Add(int num1, int num2)
        //    //{
        //    //    return (num1 + num2);
        //    //}


        int GetResultFromDatabaseServer()
        {
            return new Random().Next();
        }
    static void Main(string[] args)
        {
        //Console.WriteLine("Hello, World!");
        //Program program = new Program();
        //calcDel c1 = new calcDel(program.Add);
        //calcDel<int> c1 = new calcDel<int>(program.Add);//Generic type instantiation
        //calcDel<int> c1 = delegate (int num1, int num2)//You can do if you are alwayts going to use teh ref to use the method
        //{
        //    return (num1 + num2);
        //};
        // calcDel<int> c1 = (int num1, int num2) => (num1 + num2);
        //Func<int,int,int> c1 = (int num1, int num2) => (num1 + num2);
        //program.Calculate(c1);
        //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
        //int[] another = new int[numbers.Length];
        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    if (numbers[i] > 80)
        //        another[i] = numbers[i];
        //}
        //for (int i = 0;i < another.Length; i++)
        //{
        //    Console.WriteLine(another[i]);
        //}
        //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
        //select * from numbers where num>80
        // var another = from n in numbers where n > 80 select n;
        //var another = numbers.Where(n => n > 80);
        //foreach (int n in another)
        //    Console.WriteLine(n);
        //var another = numbers.OrderBy(n => n);
        //foreach(int n in another)
        //    Console.WriteLine(n);
        //IRepository<int, Customer> customerRepo = new CustomerRepository();
        //customerRepo.Add(new Customer { Id = 1, Name = "Ramu", Age = 23 });
        //customerRepo.Add(new Customer { Id = 2, Name = "Somu", Age = 31 });
        //customerRepo.Add(new Customer { Id = 3, Name = "Komu", Age = 27 });
        //var customers = customerRepo.GetAll().ToList();
        //customers.Sort(new SortCustomerByName());
        //customers = customers.OrderBy(cust => cust.Age).ToList();
        //customers = customers.OrderByDescending(cust => cust.Age).ThenBy(cust => cust.Name).ToList();
        //foreach (var item in customers)
        //{
        //    Console.WriteLine(item);
        //}
        //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };

        //int[] evenNumebrs = numbers.EvenCatch();
        //foreach (int n in evenNumebrs)
        //    Console.WriteLine(n);
        //string message = "Hello World";
        //message = message.Reverse();
        //Console.WriteLine(message);
        Console.WriteLine("Hello, World!");
        Program program = new Program();
        int number = program.GetResultFromDatabaseServer();
        Console.WriteLine("This is the random number from main" + new Random().Next());
        Console.WriteLine("This is the random number from server " + number);
    }
  }

        //public static class StringMethods
        //{
        //    public static string Reverse(this string msg)
        //    {
        //        char[] chars = msg.ToCharArray();
        //        Array.Reverse(chars);
        //        return new string(chars);
        //    }

        //}
        //public static class NumberExtension
        //{
        //    public static int[] EvenCatch(this int[] nums)
        //    {
        //        List<int> result = new List<int>();
        //        foreach (int num in nums)
        //            if (num % 2 == 0)
        //                result.Add(num);
        //        return result.ToArray();
        //    }
        //}
  
}
