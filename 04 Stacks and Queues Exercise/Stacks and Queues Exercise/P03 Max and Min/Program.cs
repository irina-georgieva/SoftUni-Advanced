using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Max_and_Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int querie = input[0];

                if (querie == 1)
                {
                    int element = input[1];
                    numbers.Push(element);
                }
                else if (querie == 2)
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }
                else if (querie == 3)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }
                else if (querie == 4)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
