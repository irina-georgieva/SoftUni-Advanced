using System;

namespace P04_Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string arr = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int row = 0; row < n; row++)
            {
                if (isFound)
                {
                    break;
                }
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
