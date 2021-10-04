using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = number => number % 2 == 0;
            Action<int[]> printIntegers = inputNumbers 
                => Console.WriteLine(string.Join(" ", inputNumbers));

            List<int> numbers = new List<int>();
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            string evenOdd = Console.ReadLine();

            if (evenOdd == "even")
            {
                
                printIntegers(numbers.Where(x => isEven(x)).ToArray());
            }
            else
            {
                printIntegers(numbers.Where(x => !isEven(x)).ToArray());
            }
        }
    }
}
