using System;
using System.Linq;

namespace P09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            string[] cmds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            AddAllFieldPossitions(field);

            int coalCount = GetCoalCount(field);
            int[] startCoordinates = GetStartCoordinates(field);
            int currPositionRow = startCoordinates[0];
            int currPositionCol = startCoordinates[1];

            for (int index = 0; index < cmds.Length; index++)
            {
                string action = cmds[index];

                if (action == "up")
                {
                    if (currPositionRow - 1 < 0)
                    {
                        continue;
                    }

                    currPositionRow -= 1;

                    if (field[currPositionRow, currPositionCol] == 'e')
                    {
                        Console.WriteLine($"Game over!({currPositionRow}, {currPositionCol})");
                        return;
                    }

                    else if (field[currPositionRow, currPositionCol] == 'c')
                    {
                        field[currPositionRow, currPositionCol] = '*';
                        coalCount--;
                    }
                }

                else if (action == "right")
                {
                    if (currPositionCol + 1 > columns - 1)
                    {
                        continue;
                    }

                    currPositionCol += 1;

                    if (field[currPositionRow, currPositionCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                        return;
                    }

                    else if (field[currPositionRow, currPositionCol] == 'c')
                    {
                        field[currPositionRow, currPositionCol] = '*';
                        coalCount--;
                    }
                }


                else if (action == "left")
                {
                    if (currPositionCol - 1 < 0)
                    {
                        continue;
                    }

                    currPositionCol -= 1;

                    if (field[currPositionRow, currPositionCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                        return;
                    }

                    else if (field[currPositionRow, currPositionCol] == 'c')
                    {
                        field[currPositionRow, currPositionCol] = '*';
                        coalCount--;
                    }
                }
                else if (action == "down")
                {
                    if (currPositionRow + 1 > rows - 1)
                    {
                        continue;
                    }

                    currPositionRow += 1;

                    if (field[currPositionRow, currPositionCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                        return;
                    }

                    else if (field[currPositionRow, currPositionCol] == 'c')
                    {
                        field[currPositionRow, currPositionCol] = '*';
                        coalCount--;
                    }
                }

                if (coalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({ currPositionRow}, { currPositionCol})");
                }
            }

            if (coalCount > 0)
            {
                Console.WriteLine($"{coalCount} coals left. ({currPositionRow}, {currPositionCol})");
            }
        }

        static void AddAllFieldPossitions(char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                char[] currRowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    int index = col;
                    field[row, col] = currRowValues[index];
                }
            }
        }

        static int GetCoalCount(char[,] field)
        {
            int coalCount = 0;

            foreach (char position in field)
            {
                if (position == 'c')
                {
                    coalCount++;
                }
            }

            return coalCount;
        }

        static int[] GetStartCoordinates(char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);
            int[] startingCoordinates = new int[2];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (field[row, col] == 's')
                    {
                        startingCoordinates = new int[] { row, col };
                    }
                }
            }

            return startingCoordinates;
        }
    }
}


