using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> printCollection = input
            => input.ForEach(x => Console.WriteLine($"Sir {x}"));

            List<string> input = Console.ReadLine().Split().ToList();

            printCollection(input);
        }
    }
}
