using System;
using System.Linq;

namespace P02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                int[] currRowValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    matrix[i, j] = currRowValues[j];
                }
            }

            for (int col = 0; col < columns; col++)
            {
                int currRowSum = 0;

                for (int row = 0; row < rows; row++)
                {
                    currRowSum += matrix[row, col];
                }

                Console.WriteLine(currRowSum);
            }
        }
    }
}
