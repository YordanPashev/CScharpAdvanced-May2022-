using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int rows = squareMatrixSize;
            int columns = squareMatrixSize;

            char[,] forest = CreateForest(squareMatrixSize, rows, columns);
            Dictionary<string, int> petersTruffles = new Dictionary<string, int>
            {
                {"Black truffle", 0},
                {"Summer truffle", 0},
                {"White truffle", 0}
            };

            Dictionary<string, int> wildBoarsTruffles = new Dictionary<string, int>
            {
                {"Black truffle", 0},
                {"Summer truffle", 0},
                {"White truffle", 0}
            };


            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (action == "Collect")
                {
                    CheckForTruffles(forest, row, col, petersTruffles);
                }

                else if (action == "Wild_Boar")
                {
                    string direction = cmdArgs[3];
                    WildBoarAppears(forest, row, col, direction, wildBoarsTruffles);
                }
            }

            Console.WriteLine($"Peter manages to harvest {petersTruffles["Black truffle"]} black, {petersTruffles["Summer truffle"]} summer, and {petersTruffles["White truffle"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarsTruffles["Black truffle"] + wildBoarsTruffles["Summer truffle"] + wildBoarsTruffles["White truffle"]} truffles.");
            DisplayForest(forest, rows, columns);
        }

        private static void DisplayForest(char[,] forest, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(forest[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void WildBoarAppears(char[,] forest, int row, int col, string direction, Dictionary<string, int> wildBoarsTruffles)
        {

            while (IsWildBoarInTheForest(forest, row, col))
            {
                CheckForTruffles(forest, row, col, wildBoarsTruffles);

                if (direction == "up")
                {
                    row -= 2;
                }


                else if (direction == "down")
                {
                    row += 2;
                }

                else if (direction == "left")
                {
                    col -= 2;
                }

                else if (direction == "right")
                {
                    col += 2;
                }
            }
        }

        private static bool IsWildBoarInTheForest(char[,] forest, int row, int col)
        {
            if (row >= forest.GetLength(0) || row < 0 ||
                col >= forest.GetLength(1) || col < 0)
            {
                return false;
            }

            return true;
        }

        private static void CheckForTruffles(char[,] forest, int row, int col, Dictionary<string, int> truffles)
        {
            if (forest[row, col] == 'B')
            {
                truffles["Black truffle"]++;
            }

            else if (forest[row, col] == 'S')
            {
                truffles["Summer truffle"]++;
            }

            else if (forest[row, col] == 'W')
            {
                truffles["White truffle"]++;
            }

            forest[row, col] = '-';
        }

        private static char[,] CreateForest(int squareMatrixSize, int rows, int columns)
        {
            char[,] forest = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                char[] currRowElements = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(x => char.Parse(x))
                                        .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    int elementIndex = col;

                    forest[row, col] = currRowElements[elementIndex];
                }
            }

            return forest;
        }
    }
}
