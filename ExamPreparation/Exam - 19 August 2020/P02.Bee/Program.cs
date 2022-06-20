using System;

namespace P02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int rows = squareMatrixSize;
            int columns = squareMatrixSize;

            int polinationedFlowers = 0;

            char[,] field = CreateField(rows, columns);
            int[] positionOftheBee = FindStaringPosition(field, rows, columns);
            int currRow = positionOftheBee[0];
            int currCol = positionOftheBee[1];

            string cmd = string.Empty;
            while ((cmd = Console.ReadLine()) != "End")
            {
                field[currRow, currCol] = '.';

                positionOftheBee = Move(field, cmd, currRow, currCol, rows, columns);
                currRow = positionOftheBee[0];
                currCol = positionOftheBee[1];

                if (!IsBeeInOnTheFiled(currRow, currCol, rows, columns))
                {
                    break;
                }

                if (field[currRow, currCol] == 'O')
                {
                    field[currRow, currCol] = '.';
                    positionOftheBee = Move(field, cmd, currRow, currCol, rows, columns);
                    currRow = positionOftheBee[0];
                    currCol = positionOftheBee[1];
                }

                if (field[currRow, currCol] == 'f')
                {
                    polinationedFlowers++;
                }

                field[currRow, currCol] = 'B';
            }

            if (!IsBeeInOnTheFiled(currRow, currCol, rows, columns))
            {
                Console.WriteLine("The bee got lost!");
            }

            if (polinationedFlowers < 5)
            {
                int neededpolinationFlowers = 5 - polinationedFlowers;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {neededpolinationFlowers} flowers more");
            }

            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");
            }

            DisplayFiled(field, rows, columns);
        }

        private static void DisplayFiled(char[,] field, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < columns; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static int[] Move(char[,] field, string cmd, int currRow, int currCol, int rows, int columns)
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

        private static bool IsBeeInOnTheFiled(int currRow, int currCol, int rows, int columns)
        {
            if (currRow >= rows || currRow < 0 ||
                currCol >= columns || currCol < 0)
            {
                return false;
            }

            return true;
        }

        private static int[] FindStaringPosition(char[,] field, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < columns; col++)
                {
                    int currRowCol = col;
                    if (field[row, col] == 'B')
                    {
                        return new int[2] { row, col };
                    }
                }
            }

            return null;
        }

        private static char[,] CreateField(int rows, int columns)
        {
            char[,] field = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string currRowValues = Console.ReadLine();

                for (int col = 0; col < columns; col++)
                {
                    int currRowCol = col;
                    field[row, col] = currRowValues[currRowCol];
                }
            }

            return field;
        }
    }
}
