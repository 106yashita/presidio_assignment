namespace ClassApp
{
    internal class Program
    {
        //void UnderstandingJaggedArray()
        //{
        //    string[][] posts = new string[4][];
        //    for (int i = 0; i < posts.Length; i++)
        //    {
        //        Console.WriteLine("Please enter the number of columns");
        //        int count = Convert.ToInt32(Console.ReadLine());
        //        posts[i] = new string[count];
        //        for (int j = 0; j < count; j++)
        //        {
        //            Console.WriteLine($"Please enter the post {i + 1} value");
        //            posts[i][j] = Console.ReadLine();
        //        }
        //    }
        //    Console.WriteLine("Posts");
        //    for (int i = 0; i < posts.Length; i++)
        //    {
        //        for (int j = 0; j < posts[i].Length; j++)
        //            Console.Write(posts[i][j] + " ");
        //        Console.WriteLine("---------------------");
        //    }
        //}

        int Divide(int num1, int num2)
        {
            try
            {
                int result = num1 / num2;
                return result;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("You are trying to divide by zero. Its not worth");
            }
            finally
            {
                Console.WriteLine("Release the divide method resource");
            }
            Console.WriteLine("Your division did not go well");
            return 0;

        }
        static void Main(string[] args)
        {
            int num1, num2, result;
            try
            {
                num1 = Convert.ToInt32(Console.ReadLine());
                num2 = Convert.ToInt32(Console.ReadLine());
                result = new Program().Divide(num1, num2);
                Console.WriteLine(result);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("The given data could not be converted to number.");
            }
            Console.WriteLine("Bye bye");
        }
    }
}
