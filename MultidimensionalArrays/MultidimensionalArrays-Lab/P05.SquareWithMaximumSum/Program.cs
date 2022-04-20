using System;
using System.Linq;

namespace P05.SquareWithMaximumSum
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

            for (int row = 0; row < rows; row++)
            {
                int[] currRowValues = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currRowValues[col];
                }
            }

            int maxValue = int.MinValue;
            int[] biggestSumSquareElements = new int[4];

            for (int row = 0; row < rows; row++)
            {
                int currSquareSum = 0;

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

                    currSquareSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (currSquareSum > maxValue)
                    {
                        maxValue = currSquareSum;
                        biggestSumSquareElements[0] = matrix[row, col];
                        biggestSumSquareElements[1] = matrix[row, col + 1];
                        biggestSumSquareElements[2] = matrix[row + 1, col];
                        biggestSumSquareElements[3] = matrix[row + 1, col + 1];
                    }
                }
            }

            Console.WriteLine($"{biggestSumSquareElements[0]} {biggestSumSquareElements[1]}");
            Console.WriteLine($"{biggestSumSquareElements[2]} {biggestSumSquareElements[3]}");
            Console.WriteLine(maxValue);
        }
    }
}
