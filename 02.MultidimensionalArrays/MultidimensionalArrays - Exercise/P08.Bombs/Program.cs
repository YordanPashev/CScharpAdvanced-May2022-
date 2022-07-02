using System;
using System.Linq;

namespace P08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());
            int rows = matrixSize;
            int columns = matrixSize;
            int[,] field = new int[rows, columns];

            AddAllValuesToMatrix(field, rows, columns);

            string[] bombCoordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] currBombCoordinates = bombCoordinates[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                int row = currBombCoordinates[0];
                int col = currBombCoordinates[1];

                TryToDetonateCurrBom(field, row, col);
            }

            PrintResult(field);
        }

        static int[,] AddAllValuesToMatrix(int[,] field, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] currRowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    int index = col;
                    field[row, col] = currRowValues[index];
                }
            }

            return field;
        }

        static void TryToDetonateCurrBom(int[,] field, int row, int col)
        {
            int bombValue = field[row, col];

            if (field[row, col] <= 0)
            {
                return;
            }

            field[row, col] = 0;

            int[,] bombArea = new int[8, 2]
            {
               { row - 1, col - 1 },
               { row - 1, col },
               { row - 1, col + 1 },
               { row, col - 1 },
               { row, col + 1 },
               { row + 1, col - 1 },
               { row + 1, col },
               { row + 1, col + 1 },
            };

            for (int i = 0; i < bombArea.GetLength(0); i++)
            {
                int currRow = bombArea[i, 0];
                int currCol = bombArea[i, 1];

                if (currRow > field.GetLength(0) - 1 || currRow < 0 ||
                    currCol > field.GetLength(1) - 1 || currCol < 0)
                {
                    continue;
                }

                if (field[currRow, currCol] > 0)
                {
                    field[currRow, currCol] -= bombValue;
                }
            }
        }

        static void PrintResult(int[,] field)
        {
            int activeCellCounter = 0;
            int activeCellSum = 0;

            foreach (int digit in field)
            {
                if (digit > 0)
                {
                    activeCellSum += digit;
                    activeCellCounter++;
                }
            }

            Console.WriteLine($"Alive cells: {activeCellCounter}");
            Console.WriteLine($"Sum: {activeCellSum}");

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
