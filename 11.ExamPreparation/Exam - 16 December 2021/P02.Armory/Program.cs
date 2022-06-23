using System;

namespace P02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int rows = squareMatrixSize;
            int columns = squareMatrixSize;

            char[,] armory = CreateAromry(rows, columns);
            int[] initialPosotion = FindCoordinates(armory, 'A');
            int currRow = initialPosotion[0];
            int currCol = initialPosotion[1];
            int amountOfCoins = 0;

            while (amountOfCoins < 65)
            {
                string cmd = Console.ReadLine();

                armory[currRow, currCol] = '-';
                int[] currPosition = Move(cmd, currRow, currCol);
                currRow = currPosition[0];
                currCol = currPosition[1];

                if (!IsInRangeOfArmory(currRow, currCol, rows, columns))
                {
                    break;
                }

                if (char.IsDigit(armory[currRow, currCol]))
                {
                    amountOfCoins += armory[currRow, currCol] - 48;
                    armory[currRow, currCol] = 'A';
                }

                else if (armory[currRow, currCol] == 'M')
                {
                    armory[currRow, currCol] = '-';
                    currPosition = Teleport(armory, currRow, currCol);
                    currRow = currPosition[0];
                    currCol = currPosition[1];
                }
            }

            DisplayResult(armory, amountOfCoins);
        }

        private static void DisplayResult(char[,] armory, int amountOfCoins)
        {
            var bladesResult = amountOfCoins < 65 ? "I do not need more swords!" :
                                                       "Very nice swords, I will come back for more!";

            Console.WriteLine(bladesResult);
            Console.WriteLine($"The king paid {amountOfCoins} gold coins.");

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static int[] Move(string cmd, int currRow, int currCol)
        {
            if (cmd == "up")
            {
                currRow--;
            }

            else if (cmd == "down")
            {
                currRow++;
            }

            else if (cmd == "left")
            {
                currCol--;
            }

            else if (cmd == "right")
            {
                currCol++;
            }

            return new int[2] { currRow, currCol };
        }

        private static int[] Teleport(char[,] armory, int currRow, int currCol)
        {
            int[] destinationCoordinates = FindCoordinates(armory, 'M');
            currRow = destinationCoordinates[0];
            currCol = destinationCoordinates[1];
            armory[currRow, currCol] = 'A';
            return new int[2] { currRow, currCol };
        }

        private static bool IsInRangeOfArmory(int currRow, int currCol, int rows, int columns)
        {
            if (currRow < 0 || currRow >= rows ||
                currCol < 0 || currCol >= columns)
            {
                return false;
            }

            return true;
        }

        private static int[] FindCoordinates(char[,] armory, char obj)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == obj)
                    {
                        return new int[2] { row, col };
                    }
                }
            }

            return null;
        }

        private static char[,] CreateAromry(int rows, int columns)
        {
            char[,] armory = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string currRowElements = Console.ReadLine();

                for (int col = 0; col < columns; col++)
                {
                    int elemenetIndex = col;
                    armory[row, col] = currRowElements[elemenetIndex];
                }
            }

            return armory;
        }
    }
}
