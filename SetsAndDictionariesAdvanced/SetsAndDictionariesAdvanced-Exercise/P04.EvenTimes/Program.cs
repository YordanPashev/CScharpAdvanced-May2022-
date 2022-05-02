using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int countOfDigits = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfDigits; i++)
            {
                int currDigit = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(currDigit))
                {
                    numbers[currDigit] += 1;
                    continue;
                }

                numbers.Add(currDigit, 1);
            }

            foreach (var digit in numbers)
            {
                if (digit.Value % 2 == 0)
                {
                    Console.WriteLine(digit.Key);
                    break;
                }
            }
        }
    }
}