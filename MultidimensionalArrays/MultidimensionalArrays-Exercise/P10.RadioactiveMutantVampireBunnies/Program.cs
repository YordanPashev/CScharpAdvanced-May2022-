using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bunnyLairSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            
            int rows = bunnyLairSize[0];
            int columns = bunnyLairSize[1];

            char[,] bunnyLair = new char[rows, columns];

            AddAllFieldPossitions(bunnyLair);

            string cmds = Console.ReadLine();
            int[] startCoordinates = GetStartingCoordinates(bunnyLair);
            int currPositionRow = startCoordinates[0];
            int currPositionCol = startCoordinates[1];

            foreach (char cmd in cmds)
            {
                int nextPossitionRow = currPositionRow;
                int nextPossitionCol = currPositionCol;

                if (cmd == 'U')
                {
                    nextPossitionRow -= 1;
                }

                else if (cmd == 'D')
                {
                    nextPossitionRow += 1;
                }

                else if (cmd == 'R')
                {
                    nextPossitionCol += 1;

                }

                else if (cmd == 'L')
                {
                    nextPossitionCol -= 1;
                }

                int[][] bunnies = new int[rows * columns][];
                int index = 0;

                bunnyLair[currPositionRow, currPositionCol] = '.';

                for (int row = 0; row < bunnyLair.GetLength(0); row++)
                {
                    for (int col = 0; col < bunnyLair.GetLength(1); col++)
                    {
                        if (bunnyLair[row, col] == 'B')
                        {
                            bunnies[index] = new int[2] {row, col };
                            index++;
                        }
                    }
                }

                foreach (int[] bunny in bunnies)
                {
                    if (bunny == null)
                    {
                        break;
                    }

                    TryToSpreadBunnies(bunnyLair, bunny[0], bunny[1]);
                }

                if (!IsIndexInRange(bunnyLair, nextPossitionRow, nextPossitionCol))
                {

                    DisplayBunnyLair(bunnyLair);
                    Console.WriteLine($"won: {currPositionRow} {currPositionCol}");
                    Environment.Exit(0);
                }

                currPositionRow = nextPossitionRow;
                currPositionCol = nextPossitionCol;

                if (bunnyLair[currPositionRow, currPositionCol] == 'B')
                {
                    DisplayBunnyLair(bunnyLair);
                    Console.WriteLine($"dead: {currPositionRow} {currPositionCol}");
                    Environment.Exit(0);

                }

                else
                {
                    bunnyLair[currPositionRow, currPositionCol] = 'P';
                }
            }
        }

        static void AddAllFieldPossitions(char[,] bunnyLair)
        {
            int rows = bunnyLair.GetLength(0);
            int columns = bunnyLair.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                string currRowValues = Console.ReadLine();

                for (int col = 0; col < columns; col++)
                {
                    int index = col;
                    bunnyLair[row, col] = currRowValues[index];
                }
            }
        }

        static int[] GetStartingCoordinates(char[,] bunnyLair)
        {
            int rows = bunnyLair.GetLength(0);
            int columns = bunnyLair.GetLength(1);
            int[] startingCoordinates = new int[2];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (bunnyLair[row, col] == 'P')
                    {
                        startingCoordinates = new int[] { row, col };
                        break;
                    }
                }
            }

            return startingCoordinates;
        }

        static bool IsIndexInRange(char[,] bunnyLair, int currRow, int currCol)
        {
            if (currRow > bunnyLair.GetLength(0) - 1 || currRow < 0 ||
                currCol > bunnyLair.GetLength(1) - 1 || currCol < 0)
            {
                return false;
            }

            return true;
        }
        static void TryToSpreadBunnies(char[,] bunnyLair, int currRow, int currCol)
        {

            if (IsIndexInRange(bunnyLair, currRow + 1, currCol))
            {
                bunnyLair[currRow + 1, currCol] = 'B';
            }

            if (IsIndexInRange(bunnyLair, currRow - 1, currCol))
            {
                bunnyLair[currRow - 1, currCol] = 'B';
            }

            if (IsIndexInRange(bunnyLair, currRow, currCol - 1))
            {
                bunnyLair[currRow, currCol - 1] = 'B';
            }

            if (IsIndexInRange(bunnyLair, currRow, currCol + 1))
            {
                bunnyLair[currRow, currCol + 1] = 'B';
            }
        }

        static void DisplayBunnyLair(char[,] bunnyLair)
        {
            for (int row = 0; row < bunnyLair.GetLength(0); row++)
            {
                for (int col = 0; col < bunnyLair.GetLength(1); col++)
                {
                    Console.Write(bunnyLair[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
