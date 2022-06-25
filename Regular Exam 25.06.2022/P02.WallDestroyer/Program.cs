using System;

namespace P02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquareWall = int.Parse(Console.ReadLine());

            char[,] wall = CreateWall(sizeOfSquareWall);
            int[] vankosInitialPosition = FindPosition(wall, 'V');
            int currRow = vankosInitialPosition[0];
            int currCol = vankosInitialPosition[1];
            int numberOfHoles = 1;
            int hittedRodsCount = 0;
            bool isElectracuted = false;

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                int lastPositionRow = currRow;
                int lastPositionCol = currCol;  
                int[] nextPositionCoordinates = TryToMove(wall, currRow, currCol, cmd);
                currRow = nextPositionCoordinates[0];
                currCol = nextPositionCoordinates[1];

                if (wall[currRow, currCol] == '-')
                {
                    wall[lastPositionRow, lastPositionCol] = '*';
                    wall[currRow, currCol] = 'V';
                    numberOfHoles++;
                }

                else if (wall[currRow, currCol] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    hittedRodsCount++;
                    currRow = lastPositionRow;
                    currCol = lastPositionCol;
                }

                else if (wall[currRow, currCol] == 'C')
                {
                    isElectracuted = true;
                    numberOfHoles++;
                    wall[lastPositionRow, lastPositionCol] = '*';
                    wall[currRow, currCol] = 'E';
                    break;
                }

                else if (wall[currRow, currCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{currRow}, {currCol}]!");
                    wall[lastPositionRow, lastPositionCol] = '*';
                    wall[currRow, currCol] = 'V';
                }
            }

            DisplayResults(wall, isElectracuted, numberOfHoles, hittedRodsCount);
        }

        private static void DisplayResults(char[,] wall, bool isElectracuted, int numberOfHoles, int hittedRodsCount)
        {
            if (isElectracuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {numberOfHoles} hole(s).");
            }

            else
            {
                Console.WriteLine($"Vanko managed to make {numberOfHoles} hole(s) and he hit only {hittedRodsCount} rod(s).");
            }

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static int[] TryToMove(char[,] wall, int currRow, int currCol, string cmd)
        {
            if (cmd == "up" && currRow - 1 >= 0)
            {
                currRow--;
            }

            else if (cmd == "down" && currRow + 1 < wall.GetLength(0))
            {
                currRow++;
            }

            else if (cmd == "left" && currCol - 1 >= 0)
            {
                currCol--;
            }

            else if (cmd == "right" && currCol + 1 < wall.GetLength(1))
            {
                currCol++;
            }

            return new int[2] { currRow, currCol };
        }

        private static int[] FindPosition(char[,] wall, char obj)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    if (wall[row, col] == 'V')
                    {
                        return new int[2] { row, col };
                    }
                }
            }

            return null;
        }

        private static char[,] CreateWall(int sizeOfSquareWall)
        {
            int rows = sizeOfSquareWall;
            int columns = sizeOfSquareWall;

            char[,] wall = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                string currRowElements = Console.ReadLine();

                for (int col = 0; col < columns; col++)
                {
                    int elementIndex = col;
                    wall[row, col] = currRowElements[elementIndex];
                }
            }

            return wall;
        }
    }
}
