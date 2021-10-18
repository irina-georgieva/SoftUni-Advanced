using System;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] battleField = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                battleField[row] = Console.ReadLine().Select(x => x).ToArray();
            }

            int armyRow = 0;
            int armyCol = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < battleField[row].Length; col++)
                {
                    if (battleField[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                        battleField[armyRow][armyCol] = '-';
                    }
                }
            }

            string command = Console.ReadLine();

            while (armor > 0)
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                int orcRow = int.Parse(commandArgs[1]);
                int orcCol = int.Parse(commandArgs[2]);
                battleField[orcRow][orcCol] = 'O';

                if (direction == "up" && IsCellValid(armyRow - 1, armyCol,
                    rows, battleField[armyRow].Length))
                {
                    armyRow = armyRow - 1;
                }

                else if (direction == "down" && IsCellValid(armyRow + 1, armyCol,
                    rows, battleField[armyRow].Length))
                {
                    armyRow = armyRow + 1;

                }
                else if (direction == "left" && IsCellValid(armyRow, armyCol - 1,
                    rows, battleField[armyRow].Length))
                {

                    armyCol = armyCol - 1;
                }

                else if (direction == "right" && IsCellValid(armyRow, armyCol + 1,
                    rows, battleField[armyRow].Length))
                {

                    armyCol = armyCol + 1;   
                }

                armor--;

                if (armor <= 0)
                {
                    battleField[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                if (battleField[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                    if (armor > 0)
                    {
                        battleField[armyRow][armyCol] = '-';
                    }
                    else if (armor <= 0)
                    {
                        battleField[armyRow][armyCol] = 'X';
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        break;
                    }
                }
                else if (battleField[armyRow][armyCol] == 'M')
                {
                    battleField[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                command = Console.ReadLine();
            }

            foreach (var row in battleField)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        static bool IsCellValid(int armyRow, int armyCol, int rows, int cols)
        {
            return armyRow >= 0 && armyCol >= 0 && armyRow < rows && armyCol < cols;
        }
    }
}