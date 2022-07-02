using System;
using System.Linq;

namespace P04.MatrixShuffling
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
            string[,] matrix = new string[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string[] currRowSumbols = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                AddSymbolsToCurrRow(matrix, currRowSumbols, row, columns);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool isCmdArgsValid = CheckCmdArgs(cmdArgs, matrix);

                if (!isCmdArgsValid)
                {
                    Console.WriteLine("Invalid input!");
                }

                else
                {
                    SwapValues(cmdArgs, matrix);
                    PrintMatrix(matrix);
                }
            }
        }

        static void AddSymbolsToCurrRow(string[,] matrix, string[] currRowSumbols, int row, int columns)
        {
            for (int col = 0; col < columns; col++)
            {
                matrix[row, col] = currRowSumbols[col];
            }
        }

        static bool CheckCmdArgs(string[] cmdArgs, string[,] matrix)
        {
            if (cmdArgs.Length != 5)
            {
                return false;
            }


            int firstItemRow = int.Parse(cmdArgs[1]);
            int firstItemCol = int.Parse(cmdArgs[2]);
            int secondItemRow = int.Parse(cmdArgs[3]);
            int secondItemCol = int.Parse(cmdArgs[4]);

            if (firstItemRow > matrix.GetLength(0) - 1 || firstItemRow < 0 ||
                     firstItemCol > matrix.GetLength(1) - 1 || firstItemCol < 0)
            {
                return false;
            }

            else if (secondItemRow > matrix.GetLength(0) - 1 || secondItemRow < 0 ||
                     secondItemCol > matrix.GetLength(1) - 1 || secondItemCol < 0)
            {
                return false;
            }

            return true;
        }

        static void SwapValues(string[] cmdArgs, string[,] matrix)
        {
            int firstItemRow = int.Parse(cmdArgs[1]);
            int firstItemCol = int.Parse(cmdArgs[2]);
            int secondItemRow = int.Parse(cmdArgs[3]);
            int secondItemCol = int.Parse(cmdArgs[4]);

            string firstItemValue = matrix[firstItemRow, firstItemCol];
            matrix[firstItemRow, firstItemCol] = matrix[secondItemRow, secondItemCol];
            matrix[secondItemRow, secondItemCol] = firstItemValue;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
