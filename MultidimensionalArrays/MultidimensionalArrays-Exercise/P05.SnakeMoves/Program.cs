using System;
using System.Linq;
using System.Text;

namespace P05.SnakeMoves
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

            string snake = Console.ReadLine();

            snake = CreateExtraLongSnake(snake);

            AddValuesToMatrix(matrix, snake, rows, columns);

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void AddValuesToMatrix(char[,] matrix, string snake, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 != 0)
                {
                    for (int col = columns - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[0];
                        snake = snake.Remove(0, 1);
                    }
                }

                else
                {
                    for (int col = 0; col < columns; col++)
                    {
                        matrix[row, col] = snake[0];
                        snake = snake.Remove(0, 1);
                    }
                }
            }
        }

        static string CreateExtraLongSnake(string snake)
        {
            StringBuilder snakeString = new StringBuilder(snake);

            for (int i = 0; i < 150; i++)
            {
                snakeString.Append(snake);
            }

            return snakeString.ToString();
        }
    }
}
