using System;
using System.Linq;

namespace P06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] currRowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => double.Parse(x))
                    .ToArray();

                matrix[row] = currRowValues;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                AnalizeAndModifyCurrRows(matrix, row, row + 1);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                ProcessCmd(matrix, cmd);
            }

            PrintMatrix(matrix);
        }

        static void AnalizeAndModifyCurrRows(double[][] matrix, int currRow, int nextRow)
        {
            if (matrix[currRow].Length == matrix[nextRow].Length)
            {
                //Multiply each digit in both rows
                for (int col = 0; col < matrix[currRow].Length; col++)
                {
                    matrix[currRow][col] *= 2;
                    matrix[nextRow][col] *= 2;
                }
            }

            else
            {
                //Divide each digit in both rows
                for (int col = 0; col < matrix[currRow].Length; col++)
                {
                    matrix[currRow][col] /= 2;
                }

                for (int col = 0; col < matrix[nextRow].Length; col++)
                {
                    matrix[nextRow][col] /= 2;
                }
            }
        }

        static void ProcessCmd(double[][] matrix, string cmd)
        {
            string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            string action = cmdArgs[0];
            int row = int.Parse(cmdArgs[1]);
            int col = int.Parse(cmdArgs[2]);
            int value = int.Parse(cmdArgs[3]);

            if (!IsCmdArgValid(matrix, row, col, matrix.GetLength(0)))
            {
                return;
            }

            if (action == "Add")
            {
                matrix[row][col] += value;
            }

            else if (action == "Subtract")
            {
                matrix[row][col] -= value;
            }
        }

        static bool IsCmdArgValid(double[][] matrix, int row, int col, int rows)
        {
            if (row < 0 || row > rows - 1 ||
                col > matrix[row].Length - 1 || col < 0)
            {
                return false;
            }

            return true;
        }
        static void PrintMatrix(double[][] matrix)
        {
            foreach (double[] currRow in matrix)
            {
                Console.WriteLine(string.Join(" ", currRow));
            }
        }
    }
}
