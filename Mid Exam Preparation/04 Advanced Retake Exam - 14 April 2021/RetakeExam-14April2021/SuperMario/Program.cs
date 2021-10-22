using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int numRows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[numRows][];

            for (int row = 0; row < numRows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                        matrix[marioRow][marioCol] = '-';
                    }
                }
            }

            string command = Console.ReadLine();

            while (true)
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                int bowserRow = int.Parse(commandArgs[1]);
                int bowserCol = int.Parse(commandArgs[2]);

                matrix[bowserRow][bowserCol] = 'B';
                lives--;

                MoveNext(numRows, matrix, ref marioRow, ref marioCol, direction);

                if (matrix[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                    matrix[marioRow][marioCol] = '-';
                }
                if (lives <= 0)
                {
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    matrix[marioRow][marioCol] = 'X';
                    break;
                }
                if (matrix[marioRow][marioCol] == 'P')
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    matrix[marioRow][marioCol] = '-';
                    break;
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < numRows; row++)
            {
                Console.WriteLine(matrix[row]);
            }
        }

        private static void MoveNext(int numRows, char[][] matrix, ref int marioRow, ref int marioCol, string direction)
        {
            if (direction == "W")
            {
                if (IsValidCellRectangular(marioRow - 1, marioCol, numRows, matrix.Length))
                {
                    marioRow--;
                }
            }
            else if (direction == "S")
            {
                if (IsValidCellRectangular(marioRow + 1, marioCol, numRows, matrix.Length))
                {
                    marioRow++;
                }
            }
            else if (direction == "D")
            {
                if (IsValidCellRectangular(marioRow, marioCol + 1, numRows, matrix.Length))
                {
                    marioCol++;
                }
            }
            else if (direction == "A")
            {
                if (IsValidCellRectangular(marioRow, marioCol - 1, numRows, matrix.Length))
                {
                    marioCol--;
                }
            }
        }

        private static bool IsValidCellRectangular(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
