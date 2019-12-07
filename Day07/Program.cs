﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Day07
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine(Task1.Solve(ReadFile("input.txt")).output);
                Console.WriteLine(Task2.Solve(ReadFile("input.txt")).output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("...");
            Console.ReadLine();
        }

        private static IEnumerable<string> ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
