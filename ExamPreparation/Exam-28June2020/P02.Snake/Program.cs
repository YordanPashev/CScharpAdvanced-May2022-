using System;

namespace P02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int rows = squareMatrixSize;
            int cols = squareMatrixSize;
            char[,] field = new char[rows, cols];

            CreateTerritory(field, rows, cols);

            int[]  snakeInitialPossition = TakeSnakeInitialPossition(field, rows, cols);
            int currPossitionRow = snakeInitialPossition[0];
            int currPossitionCol = snakeInitialPossition[1];
            int eatenFoodQuantity = 0;

            while (eatenFoodQuantity < 10)
            {
                string cmd = Console.ReadLine();

                if (cmd == "up")
                {
                    field[currPossitionRow, currPossitionCol] = '.';
                    currPossitionRow--;
                }

                else if (cmd == "down")
                {
                    field[currPossitionRow, currPossitionCol] = '.';
                    currPossitionRow++;
                }

                else if (cmd == "left")
                {
                    field[currPossitionRow, currPossitionCol] = '.';
                    currPossitionCol--;
                }

                else if (cmd == "right")
                {
                    field[currPossitionRow, currPossitionCol] = '.';
                    currPossitionCol++;
                }


                if (!isSnakeInTheField(currPossitionCol, currPossitionRow, rows, cols))
                {
                    break;
                }

                else
                {
                    if (field[currPossitionRow, currPossitionCol] == '*')
                    {
                        eatenFoodQuantity++;
                        field[currPossitionRow, currPossitionCol] = 'S';
                    }

                    else if (field[currPossitionRow, currPossitionCol] == 'B')
                    {
                        field[currPossitionRow, currPossitionCol] = '.';
                        int[] secondTeleportPossition = TakesecondTeleportPossition(field, rows, cols);
                        currPossitionRow = secondTeleportPossition[0];
                        currPossitionCol = secondTeleportPossition[1];
                        field[currPossitionRow, currPossitionCol] = 'S';
                    }

                    else
                    {
                        field[currPossitionRow, currPossitionCol] = 'S';
                    }
                }

            }

            if (eatenFoodQuantity < 10)
            {
                Console.WriteLine("Game over!");
            }

            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {eatenFoodQuantity}");
            PrintField(field, rows, cols);

        }

        private static void PrintField(char[,] field, int rows, int cols)
        {
            for(int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                        Console.Write(field[ row, col ]);
                }

                Console.WriteLine();
            }
        }

        private static int[] TakesecondTeleportPossition(char[,] field, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == 'B')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return null;
        }

        private static bool isSnakeInTheField(int currPossitionCol, int currPossitionRow, int rows, int cols)
        {
            if (currPossitionCol < 0 || currPossitionCol >= cols)
            {
                return false;
            }

            else if (currPossitionRow < 0 || currPossitionRow >= rows)
            {
                return false;
            }

            return true;
        }

        private static int[] TakeSnakeInitialPossition(char[,] field, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == 'S')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return null;
        }

        private static void CreateTerritory(char[,] field, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                string currRowValues = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    int index = col;
                    field[row, col] = currRowValues[index];
                }
            }
        }
    }
}
