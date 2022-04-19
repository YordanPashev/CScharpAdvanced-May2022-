using System;

namespace P07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3,3];
            
            matrix[0,0] = 1;
            matrix[0,1] = 2;
            matrix[0,2] = 3;
            matrix[1,0] = 4;
            matrix[1,1] = 5;
            matrix[1,2] = 6;

            Console.WriteLine(matrix[0, 1]);
        }
    }
}
