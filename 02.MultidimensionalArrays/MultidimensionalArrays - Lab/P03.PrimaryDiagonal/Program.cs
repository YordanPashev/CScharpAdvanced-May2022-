using System;
using System.Linq;

namespace P03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int rows = matrixSize;
            int columns = matrixSize;

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

            int result = 0;

            for (int index = 0; index < rows; index++)
            {
                result += matrix[index, index];
            }

            Console.WriteLine(result);
        }
    }
}
