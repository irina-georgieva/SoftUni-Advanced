using System;
using System.Linq;

namespace P06JaggedArrManipulatio
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] *= 2;
                        matrix[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] /= 2;
                    }
                    for (int j = 0; j < matrix[row + 1].Length; j++)
                    {
                        matrix[row + 1][j] /= 2;
                    }
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                double value = int.Parse(commandArgs[3]);

                if (command == "Add" )
                {
                    if (row >= 0 && col >= 0 && row < n && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }
                else if(command == "Subtract")
                {
                    if (row >= 0 && col >= 0 && row < n && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                    else
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (double[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }

       
    }
}
