using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int rows = squareMatrixSize;
            int columns = squareMatrixSize;

            char[,] pond = CreatePond(rows, columns);
            int[] beaaverPositionAndWoodsInfo = GetBeaverPositionAndCountOfWoods(pond, rows, columns);
            int currPositionRow = beaaverPositionAndWoodsInfo[0];
            int currPositionCol = beaaverPositionAndWoodsInfo[1];
            int initialNumberOfBranchesInThePond = beaaverPositionAndWoodsInfo[2];
            int currNumberOfBranchesInThePond = initialNumberOfBranchesInThePond;
            List<char> listOfCollectedBranches = new List<char>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                beaaverPositionAndWoodsInfo = GetBeaverPositionAndCountOfWoods(pond, rows, columns);
                currPositionRow = beaaverPositionAndWoodsInfo[0];
                currPositionCol = beaaverPositionAndWoodsInfo[1];
                pond[currPositionRow, currPositionCol] = '-';
                int beaverLastPositionRow = currPositionRow;
                int beaverLastPositionCol = currPositionCol;

                if (cmd == "up")
                {
                    currPositionRow--;
                }

                else if (cmd == "down")
                {
                    currPositionRow++;
                }

                else if (cmd == "left")
                {
                    currPositionCol--;
                }

                else if (cmd == "right")
                {
                    currPositionCol++;
                }

                if (IsBeaverGoOutsideThePond(pond, currPositionRow, currPositionCol, rows, columns))
                {
                    currPositionRow = beaverLastPositionRow;
                    currPositionCol = beaverLastPositionCol;
                    pond[currPositionRow, currPositionCol] = 'B';

                    if (listOfCollectedBranches.Count > 0)
                    {
                        int lastWoodIndex = listOfCollectedBranches.Count - 1;
                        listOfCollectedBranches.RemoveAt(lastWoodIndex);
                    }
                }

                if (char.IsLower(pond[currPositionRow, currPositionCol]))
                {
                    CollectWood(pond, currPositionRow, currPositionCol, listOfCollectedBranches);
                }

                else if (pond[currPositionRow, currPositionCol] == 'F')
                {
                    pond[currPositionRow, currPositionCol] = '-';
                    Swim(pond, currPositionRow, currPositionCol, listOfCollectedBranches, cmd);
                }

                else
                {
                    pond[currPositionRow, currPositionCol] = 'B';
                }

                beaaverPositionAndWoodsInfo = GetBeaverPositionAndCountOfWoods(pond, rows, columns);
                currNumberOfBranchesInThePond = beaaverPositionAndWoodsInfo[2];

                if (currNumberOfBranchesInThePond <= 0)
                {
                    break;
                }

                DisplayPond(pond, rows, columns);
            }

            if (currNumberOfBranchesInThePond <= 0)
            {
                Console.WriteLine($"The Beaver successfully collect {listOfCollectedBranches.Count} wood branches: {string.Join(", ", listOfCollectedBranches)}.");
            }

            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {currNumberOfBranchesInThePond} branches left.");
            }
        }

        private static void DisplayPond(char[,] pond, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void CollectWood(char[,] pond, int currPositionRow, int currPositionCol, List<char> listOfCollectedBranches)
        {
            char woodValues = pond[currPositionRow, currPositionCol];
            listOfCollectedBranches.Add(woodValues);
            pond[currPositionRow, currPositionCol] = 'B';
        }

        private static bool IsBeaverGoOutsideThePond(char[,] pond, int currPositionRow, int currPositionCol, int rows, int columns)
        {
            if (currPositionRow < 0 || currPositionRow >= rows ||
                currPositionCol < 0 || currPositionCol >= columns)
            {
                return true;
            }

            return false;
        }

        private static void Swim(char[,] pond, int currPositionRow, int currPositionCol, List<char> listOfCollectedBranches, string cmd)
        {
            if (cmd == "up")
            {
                currPositionRow = 0;
            }

            else if (cmd == "down")
            {
                currPositionRow = pond.GetLength(0) - 1;
            }

            else if (cmd == "left")
            {
                currPositionCol = 0;
            }

            else if (cmd == "right")
            {
                currPositionCol = pond.GetLength(1) - 1;
            }

            if (char.IsLower(pond[currPositionRow, currPositionCol]))
            {
                CollectWood(pond, currPositionRow, currPositionCol, listOfCollectedBranches);
            }

            if (pond[currPositionRow, currPositionCol] == 'F')
            {
                
                SwimOppositeWay(pond, currPositionRow, currPositionCol, cmd, listOfCollectedBranches);
            }

            else 
            {
                pond[currPositionRow, currPositionCol] = 'B';
            }
        }

        private static void SwimOppositeWay(char[,] pond, int currPositionRow, int currPositionCol, string cmd, List<char> listOfCollectedBranches)
        {
            pond[currPositionRow, currPositionCol] = '-';

            if (cmd == "up")
            {
                currPositionRow = pond.GetLength(0) - 1;
            }

            else if (cmd == "down")
            {
                currPositionRow = 0;
            }

            else if (cmd == "left")
            {
                currPositionCol = pond.GetLength(1) - 1;
            }

            else if (cmd == "right")
            {
                currPositionCol = 0;
            }

            if (char.IsLower(pond[currPositionRow, currPositionCol]))
            {
                CollectWood(pond, currPositionRow, currPositionCol, listOfCollectedBranches);
            }

            pond[currPositionRow, currPositionCol] = 'B';
        }

        private static int[] GetBeaverPositionAndCountOfWoods(char[,] pond, int rows, int columns)
        {
            int initialBevarPosRow = 0;
            int initialBevarPosCol = 0;
            int numberOfBranches = 0;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (pond[row, col] == 'B')
                    {
                        initialBevarPosRow = row;
                        initialBevarPosCol = col;
                    }

                    else if (char.IsLower(pond[row, col]) && pond[row, col] != '-')
                    {
                        numberOfBranches++;
                    }
                }
            }

            return new int[3] { initialBevarPosRow, initialBevarPosCol, numberOfBranches };
        }

        private static char[,] CreatePond(int rows, int columns)
        {
            char[,] pond = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                char[] currRowElements = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(char.Parse)
                                        .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    int elementIndex = col;
                    pond[row, col] = currRowElements[elementIndex];
                }
            }

            return pond;
        }
    }
}
