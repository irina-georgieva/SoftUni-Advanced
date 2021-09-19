using System;
using System.Linq;

namespace P05_Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            char[] snake = Console.ReadLine().ToCharArray();
            char[] tempSnake = snake;
            int snakeCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (snakeCounter < tempSnake.Length)
                        {
                            matrix[row, col] = tempSnake[snakeCounter];
                            snakeCounter++;
                        }
                        else
                        {
                            tempSnake = snake;
                            snakeCounter = 0;
                            matrix[row, col] = tempSnake[snakeCounter];
                            snakeCounter++;
                        }
                    }
                }

                if (row % 2 == 1)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (snakeCounter < tempSnake.Length)
                        {
                            matrix[row, col] = tempSnake[snakeCounter];
                            snakeCounter++;
                        }
                        else
                        {
                            tempSnake = snake;
                            snakeCounter = 0;
                            matrix[row, col] = tempSnake[snakeCounter];
                            snakeCounter++;
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}

