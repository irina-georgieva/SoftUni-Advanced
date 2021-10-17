using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {

            //Func<int, bool> isEven = (n) => n % 2 == 0;

            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int[] result = numbers.Where(x => isEven(x)).OrderBy(x => x).ToArray();

            //Console.WriteLine(string.Join(" ", result));

            Predicate<int> isEven = number => number % 2 == 0;
            Action<List<int>> printIntegers = inputNumbers
                => Console.WriteLine(string.Join(" ", inputNumbers));
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> sortedNumbers = new List<int>();

            Func<List<int>, List<int>> integers = (sortedIntegers) =>
            {

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (isEven(numbers[i]))
                    {
                        sortedNumbers.Add(numbers[i]);
                    }
                }

                sortedNumbers.Sort();

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (!isEven(numbers[i]))
                    {
                        sortedNumbers.Add(numbers[i]);
                    }
                }
                return sortedNumbers;
            };

            printIntegers(integers(sortedNumbers));




            //if (evenOdd == "even")
            //{

            //    printIntegers(numbers.Where(x => isEven(x)).ToArray());
            //}
            //else
            //{
            //    printIntegers(numbers.Where(x => !isEven(x)).ToArray());
            //}
        }
    }
}
