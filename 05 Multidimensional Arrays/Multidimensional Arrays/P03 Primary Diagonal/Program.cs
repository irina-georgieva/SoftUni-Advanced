using System;
using System.Linq;

namespace P03_Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            
            for (int row = 0; row < n; row++)
            {
                int[] arr = ReadArrayFromConsole();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += matrix[i,i];
            }

            Console.WriteLine(sum);
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}
