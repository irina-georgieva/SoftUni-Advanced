using System;
using System.Linq;

namespace P05_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> add = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] += 1;
                }
            };

            Action<int[]> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] -= 1;
                }
            };
            Action<int[]> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] *= 2;
                }
            };
            Action<int[]> printNumbers = number => Console.WriteLine(string.Join(" ", number));

            int[] inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    add(inputNumbers);
                }
                else if (command == "multiply")
                {
                    multiply(inputNumbers);
                }
                else if (command == "subtract")
                {
                    subtract(inputNumbers);
                }
                else if (command == "print")
                {
                    printNumbers(inputNumbers);
                }

                command = Console.ReadLine();
            }


        }
    }
}
