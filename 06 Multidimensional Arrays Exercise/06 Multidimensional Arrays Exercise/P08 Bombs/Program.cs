using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(n);

            List<int[]> bombsIndexes = GetBombsIndexes();

            ExplodeBombs(bombsIndexes, matrix);

            int liveCells = 0;
            int sumAliveCells = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        liveCells++;
                        sumAliveCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {liveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");

            PrintMatrix(matrix);
        }

        private static int[,] ReadMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static List<int[]> GetBombsIndexes()
        {
            string[] bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<int[]> bombsIndexes = new List<int[]>();
            for (int i = 0; i < bombs.Length; i++)
            {
                string[] bombsArgs = bombs[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(bombsArgs[0]);
                int col = int.Parse(bombsArgs[1]);

                bombsIndexes.Add(new[] { row, col });
            }

            return bombsIndexes;
        }

        static void ExplodeBombs(List<int[]> bombsIndexes, int[,] matrix)
        {
            foreach (int[] bomb in bombsIndexes)
            {
                int bombRow = bomb[0];
                int bombCol = bomb[1];

                if (matrix[bombRow, bombCol] > 0)
                {
                    if (IsCellValid(bombRow - 1, bombCol - 1, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsCellValid(bombRow - 1, bombCol, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                    }

                    if (IsCellValid(bombRow - 1, bombCol + 1, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsCellValid(bombRow, bombCol + 1, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsCellValid(bombRow + 1, bombCol + 1, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsCellValid(bombRow + 1, bombCol, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                    }

                    if (IsCellValid(bombRow + 1, bombCol - 1, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsCellValid(bombRow, bombCol - 1, matrix.GetLength(0), matrix.GetLength(1), matrix))
                    {
                        matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }
        }

        static bool IsCellValid(int bombRow, int bombCol, int rows, int cols, int[,] matrix)
        {
            return bombRow >= 0 && bombCol >= 0 && bombRow < rows && bombCol < cols && matrix[bombRow, bombCol] > 0;
        }
    }
}
