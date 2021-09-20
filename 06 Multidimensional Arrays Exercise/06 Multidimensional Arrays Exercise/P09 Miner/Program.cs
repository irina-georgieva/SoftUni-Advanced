using System;
using System.Linq;
using System.Collections.Generic;

namespace P09_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = ReadMatrix(n);

            int playerRow = -1;
            int playerCol = -1;

            int countCoal = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        countCoal++;
                    }
                }
            }

            int sumCoal = 0;

            MoveToTheDirection(directions, matrix, playerRow, playerCol, sumCoal, countCoal);
        }

        private static void MoveToTheDirection(string[] directions, char[,] matrix, int playerRow, int playerCol, int sumCoal, int countCoal)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == "left")
                {
                    if (IsValidCell(playerRow, playerCol - 1, matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        if (matrix[playerRow, playerCol - 1] == 'c' && IsAnyCoalThere(matrix))
                        {
                            sumCoal++;
                            matrix[playerRow, playerCol - 1] = '*';
                            playerCol = playerCol - 1;
                            continue;
                        }
                        else if (matrix[playerRow, playerCol - 1] == 'c' && !IsAnyCoalThere(matrix))
                        {
                            Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol - 1})");
                            return;
                        }

                        if (matrix[playerRow, playerCol - 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({playerRow}, {playerCol - 1})");
                            return;
                        }
                        else
                        {
                            playerCol = playerCol - 1;
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (directions[i] == "right")
                {
                    if (IsValidCell(playerRow, playerCol + 1, matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        if (matrix[playerRow, playerCol + 1] == 'c' && IsAnyCoalThere(matrix))
                        {
                            sumCoal++;
                            matrix[playerRow, playerCol + 1] = '*';
                            playerCol = playerCol + 1;
                            continue;
                        }
                        else if (matrix[playerRow, playerCol + 1] == 'c' && !IsAnyCoalThere(matrix))
                        {
                            Console.WriteLine($"You collected all coals! ({ playerRow}, { playerCol + 1})");
                            return;
                        }

                        if (matrix[playerRow, playerCol + 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({playerRow}, {playerCol + 1})");
                            return;
                        }
                        else
                        {
                            playerCol = playerCol + 1;
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (directions[i] == "up")
                {
                    if (IsValidCell(playerRow - 1, playerCol, matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        if (matrix[playerRow - 1, playerCol] == 'c' && IsAnyCoalThere(matrix))
                        {
                            sumCoal++;
                            matrix[playerRow - 1, playerCol] = '*';
                            playerRow = playerRow - 1;
                            continue;
                        }
                        else if (matrix[playerRow - 1, playerCol] == 'c' && !IsAnyCoalThere(matrix))
                        {

                            Console.WriteLine($"You collected all coals! ({ playerRow - 1}, { playerCol})");
                            return;
                        }

                        if (matrix[playerRow - 1, playerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({playerRow - 1}, {playerCol})");
                            return;
                        }
                        else
                        {
                            playerRow = playerRow - 1;
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (directions[i] == "down")
                {
                    if (IsValidCell(playerRow + 1, playerCol, matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        if (matrix[playerRow + 1, playerCol] == 'c' && IsAnyCoalThere(matrix))
                        {
                            sumCoal++;
                            matrix[playerRow + 1, playerCol] = '*';
                            playerRow = playerRow + 1;
                            continue;
                        }
                        else if (matrix[playerRow + 1, playerCol] == 'c' && !IsAnyCoalThere(matrix))
                        {

                            Console.WriteLine($"You collected all coals! ({ playerRow + 1}, { playerCol})");
                            return;
                        }

                        if (matrix[playerRow + 1, playerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({playerRow + 1}, {playerCol})");
                            return;
                        }
                        else
                        {
                            playerRow = playerRow + 1;
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine($"{countCoal - sumCoal} coals left. ({playerRow}, {playerCol})");
        }



        private static bool IsAnyCoalThere(char[,] matrix)
        {
            int countCoal = 0;
            foreach (var item in matrix)
            {
                if (item == 'c')
                {
                    countCoal++;
                }
            }

            if (countCoal > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] rowValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }

        private static bool IsValidCell(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}

