using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_Radioactive_Mutants
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

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool isPlayerWon = false;
            bool isPlayerDead = false;

            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerColl = playerCol;

                switch (direction)
                {
                    case 'U':
                        newPlayerRow--;
                        break;
                    case 'D':
                        newPlayerRow++;
                        break;
                    case 'L':
                        newPlayerColl--;
                        break;
                    case 'R':
                        newPlayerColl++;
                        break;
                }

                matrix[playerRow, playerCol] = '.';
                isPlayerWon = !IsValidCell(newPlayerRow, newPlayerColl, rows, cols);
                if (!isPlayerWon)
                {
                    if (matrix[newPlayerRow, newPlayerColl] == '.')
                    {
                        matrix[newPlayerRow, newPlayerColl] = 'P';
                    }
                    else if (matrix[newPlayerRow, newPlayerColl] == 'B')
                    {
                        isPlayerDead = true;
                    }

                    playerRow = newPlayerRow;
                    playerCol = newPlayerColl;
                }

                List<int[]> currBunnyIndexes = GetBunnyIndexes(matrix);
                SpreadBunnies(currBunnyIndexes, matrix);
                if (matrix[playerRow, playerCol] == 'B')
                {
                    isPlayerDead = true;
                }

                if (isPlayerWon || isPlayerDead)
                {
                    break;
                }
            }

            PrintMatrix(matrix);
            string result = string.Empty;

            if (isPlayerWon)
            {
                result += "won: ";
            }
            else
            {
                result += "dead: ";
            }

            result += $"{playerRow} {playerCol}";
            Console.WriteLine(result);
        }

        private static void PrintMatrix(char[,] matrix)
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

        static void SpreadBunnies(List<int[]> currBunnyIndexes, char[,] matrix)
        {
            foreach (int[] bunnyIndex in currBunnyIndexes)
            {
                int bunnyRow = bunnyIndex[0];
                int bunnyCol = bunnyIndex[1];
                if (IsValidCell(bunnyRow - 1, bunnyCol, matrix.GetLength(0)
                    ,matrix.GetLength(1)))
                {
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (IsValidCell(bunnyRow + 1, bunnyCol, matrix.GetLength(0)
                    , matrix.GetLength(1)))
                {
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }

                if (IsValidCell(bunnyRow, bunnyCol - 1, matrix.GetLength(0)
                    , matrix.GetLength(1)))
                {
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }

                if (IsValidCell(bunnyRow, bunnyCol + 1, matrix.GetLength(0)
                   , matrix.GetLength(1)))
                {
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        static List<int[]> GetBunnyIndexes(char[,] matrix)
        {
            List<int[]> bunnies = new List<int[]>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnies.Add(new[] { row, col });
                    }
                }
            }

            return bunnies;
        }

        private static bool IsValidCell(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
