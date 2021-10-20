using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        matrix[row, col] = '-';
                        playerRow = row;
                        playerCol = col;
                        break;
                    }
                }
            }

            bool isFound = false;

            for (int i = 0; i < countCommands; i++)
            {
                string direction = Console.ReadLine();

                int tempRow = playerRow;
                int tempCol = playerCol;

                GetNextPlayerPos(n, ref playerRow, ref playerCol, direction);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    GetNextPlayerPos(n, ref playerRow, ref playerCol, direction);
                }
                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = tempRow;
                    playerCol = tempCol;
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[playerRow, playerCol] = 'f';
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Player lost!");
                matrix[playerRow, playerCol] = 'f';
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

        private static void GetNextPlayerPos(int n, ref int playerRow, ref int playerCol, string direction)
        {
            if (direction == "up")
            {
                if (IsInMatrix(playerRow - 1, playerCol, n))
                {
                    playerRow--;
                }
                else
                {
                    playerRow = n - 1;
                }


            }
            else if (direction == "down")
            {
                if (IsInMatrix(playerRow + 1, playerCol, n))
                {
                    playerRow++;
                }
                else
                {
                    playerRow = 0;
                }
            }
            else if (direction == "right")
            {
                if (IsInMatrix(playerRow, playerCol + 1, n))
                {
                    playerCol++;
                }
                else
                {
                    playerCol = 0;
                }
            }
            else if (direction == "left")
            {
                if (IsInMatrix(playerRow, playerCol - 1, n))
                {
                    playerCol--;
                }
                else
                {
                    playerCol = n - 1;
                }
            }
        }

        static bool IsInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
