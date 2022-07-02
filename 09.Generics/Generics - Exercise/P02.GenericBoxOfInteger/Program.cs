using System;
using System.Collections.Generic;

namespace GenericBoxOfInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOFDigits = int.Parse(Console.ReadLine());
            List<Box<int>> digits = new List<Box<int>>();

            for (int i = 0; i < numberOFDigits; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> digit = new Box<int>(input);
                digits.Add(digit);
            }

            foreach (Box<int> digit in digits)
            {
                Console.WriteLine(digit);
            }
        }
    }
}
