using System;

namespace Day04
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine(Task1.Solve(124075, 580769));
                Console.WriteLine(Task2.Solve(124075, 580769));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("...");
            Console.ReadLine();
        }
    }
}
