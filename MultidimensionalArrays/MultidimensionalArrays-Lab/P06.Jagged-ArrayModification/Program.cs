using System;
using System.Linq;

namespace P06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int rows = matrixSize;
            int columns = matrixSize;
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currRowValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                matrix[row] = currRowValues;
                for (int col = 0; col < currRowValues.Length; col++)
                {
                    matrix[row][col] = currRowValues[col];
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int currValue = int.Parse(cmdArgs[3]);

                if (row > rows - 1 || col > columns - 1 ||
                    row < 0 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else if (action == "Add")
                {
                    matrix[row][col] += currValue;
                }

                else if (action == "Subtract")
                {
                    matrix[row][col] -= currValue;
                }
            }

            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
