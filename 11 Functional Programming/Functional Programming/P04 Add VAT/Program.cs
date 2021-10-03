using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).Select(x => x*1.2).ToArray();

            foreach (var number in prices)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
