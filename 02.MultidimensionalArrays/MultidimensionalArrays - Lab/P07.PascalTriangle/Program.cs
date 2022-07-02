using System;

namespace P07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong rows = ulong.Parse(Console.ReadLine());

            ulong[][] jaggedArray = new ulong[rows][];
            jaggedArray[0] = new ulong[1] { 1 };
            Console.WriteLine(string.Join(" ", jaggedArray[0]));

            for (ulong row = 1; row < rows; row++)
            {
                ulong numberOfCols = row;
                jaggedArray[row] = new ulong[numberOfCols + 1];

                for (ulong currCol = 0; currCol <= numberOfCols; currCol++)
                {
                    if (currCol == row || currCol == 0)
                    {
                        jaggedArray[row][currCol] = 1;
                    }

                    else
                    {
                        jaggedArray[row][currCol] = jaggedArray[row - 1][currCol] + jaggedArray[row - 1][currCol - 1];
                    }
                }

                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }
    }
}
