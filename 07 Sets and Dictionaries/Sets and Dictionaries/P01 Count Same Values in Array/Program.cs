using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse).ToArray();
            Dictionary<double, int> counter = new Dictionary<double, int>();

            foreach (var item in numbers)
            {
                if (counter.ContainsKey(item))
                {
                    counter[item]++;
                }
                else
                {
                    counter.Add(item, 1);
                }
            }

            foreach (var number in counter)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }

        }
    }
}
