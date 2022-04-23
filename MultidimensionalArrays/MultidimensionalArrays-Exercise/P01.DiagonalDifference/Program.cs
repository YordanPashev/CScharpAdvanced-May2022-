using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] currRowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    squareMatrix[row, col] = currRowValues[col];
                }
            }

            int primaryDiagonalSum = CalculatePrimaryDiagonalSum(matrixSize, squareMatrix);
            int secondaryDiagonalSum = CalculateSecondaryDiagonalSum(matrixSize, squareMatrix);
            int absoluteDifference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(absoluteDifference);
        }

        static int CalculatePrimaryDiagonalSum(int matrixSize, int[,] squareMatrix)
        {
            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                int col = row;
                primaryDiagonalSum += squareMatrix[row, col];
            }

            return primaryDiagonalSum;
        }

        static int CalculateSecondaryDiagonalSum(int matrixSize, int[,] squareMatrix)
        {
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                int col = matrixSize - row - 1;
                secondaryDiagonalSum += squareMatrix[row, col];
            }

            return secondaryDiagonalSum;
        }
    }
}
