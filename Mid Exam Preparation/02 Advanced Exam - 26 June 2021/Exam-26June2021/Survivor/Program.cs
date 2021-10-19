using System;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[][] matrix = new string[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string command = Console.ReadLine();
            int playerTokens = 0;
            int opponentTokens = 0;

            while (command != "Gong")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string player = commandArgs[0];
                int newRow = int.Parse(commandArgs[1]);
                int newCol = int.Parse(commandArgs[2]);

                if (player == "Find")
                {
                    if (IsCellValid(newRow, newCol, matrix))
                    {
                        int playerRow = newRow;
                        int playerCol = newCol;

                        if (matrix[newRow][newCol] == "T")
                        {
                            playerTokens++;
                            matrix[newRow][newCol] = "-";
                        }
                    }
                }
                else if (player == "Opponent")
                {
                    string direction = commandArgs[3];

                    if (IsCellValid(newRow, newCol, matrix))
                    {
                        int opponentRow = newRow;
                        int opponentCol = newCol;

                        if (matrix[newRow][newCol] == "T")
                        {
                            opponentTokens++;
                            matrix[newRow][newCol] = "-";
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            int tempRow = opponentRow;
                            int tempCol = opponentCol;

                            if (direction == "up")
                            {                         
                                 tempRow--; 
                            }
                            else if (direction == "down")
                            {
                                tempRow++;
                            }
                            else if (direction == "left")
                            {
                                tempCol--;
                            }
                            else if (direction == "right")
                            {
                                tempCol++;
                            }

                            if (IsCellValid(tempRow, tempCol, matrix))
                            {
                                opponentRow = tempRow;
                                opponentCol = tempCol;

                                if (matrix[opponentRow][opponentCol] == "T")
                                {
                                    opponentTokens++;
                                    matrix[opponentRow][opponentCol] = "-";
                                }
                            }
                        }
                    }

                }


                command = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static bool IsCellValid(int row, int col, string[][] matrix)
        {
            if (row < 0 || col < 0)
                return false;
            if (row > matrix.Length -1)
                return false;
            if (col > matrix[row].Length-1)
                return false;
            return true;
        }
    }
}
