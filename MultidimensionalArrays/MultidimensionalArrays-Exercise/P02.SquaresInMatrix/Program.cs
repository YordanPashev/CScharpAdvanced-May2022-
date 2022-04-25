using System;
using System.Linq;

namespace P02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];
            char[,] matrix = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                char[] currRowSumbols = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                AddSymbolsToCurrRow(matrix, currRowSumbols, row, columns);
            }

            int countOfSquearesOfEqualChars = GetCountOfSquearesOfEqualChars(matrix, rows, columns);



            Console.WriteLine(countOfSquearesOfEqualChars);
        }

        static void AddSymbolsToCurrRow(char[,] matrix, char[] currRowSumbols, int row, int columns)
        {
            for (int col = 0; col < columns; col++)
            {
                matrix[row, col] = currRowSumbols[col];
            }
        }

        static int GetCountOfSquearesOfEqualChars(char[,] matrix, int rows, int columns)
        {
            int countOfSquearesEqualChars = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row + 1 >= rows)
                {
                    break;
                }

                for (int col = 0; col < columns; col++)
                {
                    if (col + 1 >= columns)
                    {
                        break;
                    }

                    char symbolToCheck = matrix[row, col];

                    if (symbolToCheck == matrix[row + 1, col] && symbolToCheck == matrix[row, col + 1] &&
                        symbolToCheck == matrix[row + 1, col + 1])
                    {
                        countOfSquearesEqualChars++;
                    }
                }
            }

            return countOfSquearesEqualChars;
        }
    }
}
