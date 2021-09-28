using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            HashSet<int> leftSide = new HashSet<int>();
            HashSet<int> rightSide = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                leftSide.Add(currentNumber);
            }
            for (int i = 0; i < m; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                rightSide.Add(currentNumber);
            }

            List<int> numbers = leftSide.Intersect(rightSide).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
