using System;
using System.Linq;

namespace P02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());
            char[][] field = CraeteField(numberOfRows);
            int[] armyCoordinates = FindCoordinates(field);
            int currRow = armyCoordinates[0];
            int currCol = armyCoordinates[1];
            bool isArmyDefeated = false;

            while (!isArmyDefeated)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string direction = cmdArgs[0];
                int orcSpawnOnRow = int.Parse(cmdArgs[1]);
                int orcSpawnOnCol = int.Parse(cmdArgs[2]);
                field[orcSpawnOnRow][orcSpawnOnCol] = 'O';

                field[currRow][currCol] = '-';
                int[] nextMoveCoordinates = Move(field, direction, currRow, currCol);
                currRow = nextMoveCoordinates[0];
                currCol = nextMoveCoordinates[1];
                armor--;

                if (field[currRow][currCol] == 'O')
                {
                    armor -= 2;

                    if (armor <= 0)
                    {
                        isArmyDefeated = true;
                        field[currRow][currCol] = 'X';
                        break;
                    }
                }

                else if (field[currRow][currCol] == 'M')
                {
                    field[currRow][currCol] = '-';
                    break;
                }

                field[currRow][currCol] = 'A';

                if (armor <= 0)
                {
                    field[currRow][currCol] = 'X';
                    isArmyDefeated = true;
                    break;
                }
            }

            if (isArmyDefeated)
            {
                Console.WriteLine($"The army was defeated at {currRow};{currCol}.");
            }

            else
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
      
            DisplayField(field);
        }

        private static void DisplayField(char[][] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }

        private static int[] Move(char[][] field, string direction, int currRow, int currCol)
        {
            if (direction == "up" && currRow - 1 >= 0)
            {
                currRow--;
            }

            else if (direction == "down" && currRow + 1 < field.GetLength(0))
            {
                currRow++;
            }

            else if (direction == "left" && currCol - 1 >= 0)
            {
                currCol--;
            }

            else if (direction == "right" && currCol + 1 < field[currRow].Length)
            {
                currCol++;
            }


            return new int[] { currRow, currCol };
        }

        private static int[] FindCoordinates(char[][] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        return new int[2] { row, col };
                    }
                }
            }

            return null;
        }

        private static char[][] CraeteField(int numberOfRows)
        {
            char[][] field = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                string currRowElements = Console.ReadLine();
                int numberOfCols = currRowElements.Length;
                field[row] = new char[numberOfCols];

                for (int col = 0; col < numberOfCols; col++)
                {
                    int elementIndex = col;
                    field[row][col] = currRowElements[elementIndex];
                }
            }

            return field;
        }
    }
}
