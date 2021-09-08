using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> lineNumbers = new Queue<int>(numbers);
            int count = lineNumbers.Count;

            Queue<int> evenNumbers = new Queue<int>();

            for (int i = 0; i < count; i++)
            {
                if (lineNumbers.Peek() % 2 == 0)
                {
                    evenNumbers.Enqueue(lineNumbers.Dequeue());
                }
                else
                {
                    lineNumbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));

        }
    }
}
