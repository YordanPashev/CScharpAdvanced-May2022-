using System;
using System.Linq;

namespace P03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] currRowValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currRowValues[col];
                }
            }

            int[][] subMatrixWithMaxSum = FindSubMatrixWithMaxSum(matrix, rows, columns); ;

            PrintSubMatrixWithMaxSum(subMatrixWithMaxSum);
        }

        static int CalculateCurrSubMatrixSum(int[,] matrix, int row, int col)
        {
            return matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                   matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                   matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
        }

        static int[][] AddValuesToSubmatrix(int[,] matrix, int row, int col)
        {
            int[][] subMatrixWithMaxSum = new int[3][];

            subMatrixWithMaxSum[0] = new int[3] { matrix[row, col], matrix[row, col + 1], matrix[row, col + 2] };
            subMatrixWithMaxSum[1] = new int[3] { matrix[row + 1, col], matrix[row + 1, col + 1], matrix[row + 1, col + 2] };
            subMatrixWithMaxSum[2] = new int[3] { matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2] };

            return subMatrixWithMaxSum;
        }

        static int[][] FindSubMatrixWithMaxSum(int[,] matrix, int rows, int columns)
        {
            int maxValue = int.MinValue;
            int currSubMatrixSum = 0;

            int[][] subMatrixWithMaxSum = new int[3][];

            for (int row = 0; row < rows; row++)
            {
                if (row + 2 >= rows)
                {
                    break;
                }

                for (int col = 0; col < columns; col++)
                {
                    if (col + 2 >= columns)
                    {
                        break;
                    }

                    currSubMatrixSum = CalculateCurrSubMatrixSum(matrix, row, col);

                    if (currSubMatrixSum > maxValue)
                    {
                        maxValue = currSubMatrixSum;
                        subMatrixWithMaxSum = AddValuesToSubmatrix(matrix, row, col);
                    }
                }
            }

            return subMatrixWithMaxSum;
        }

        static void PrintSubMatrixWithMaxSum(int[][] subMatrixWithMaxSum)
        {
            int sum = 0;
            foreach (int[] currRow in subMatrixWithMaxSum)
            {
                foreach (int currDigit in currRow)
                {
                    sum += currDigit;
                }
            }

            Console.WriteLine($"Sum = {sum}");

            foreach (int[] currRow in subMatrixWithMaxSum)
            {
                Console.WriteLine(string.Join(" ", currRow));
            }
        }
    }
}
