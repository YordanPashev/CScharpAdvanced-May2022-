using System;

namespace P04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int rows = matrixSize;
            int columns = matrixSize;

            int[,] matrix = new int[rows, columns];
            bool isCointainingSymbol = false;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int i = 0; i < columns; i++)
                {
                    matrix[row, i] = input[i];
                }
            }

            char symbolToCkeck = char.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (matrix[row, col] == symbolToCkeck)
                    {
                        isCointainingSymbol = true;
                        Console.WriteLine($"({row}, {col})");
                        break;
                    }
                }

                if (isCointainingSymbol)
                {
                    break;
                }
            }

            if (!isCointainingSymbol)
            {
                Console.WriteLine($"{symbolToCkeck} does not occur in the matrix ");
            }
        }
    }
}
