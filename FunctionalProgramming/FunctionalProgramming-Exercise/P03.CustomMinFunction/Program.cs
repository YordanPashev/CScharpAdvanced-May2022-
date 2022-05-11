using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfDigits = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Func<int[], int> smallestNumber = arrayOfDigits =>
            {
                int minValue = int.MaxValue;
                int result = 0;

                foreach (int currDigit in arrayOfDigits)
                {
                    if (currDigit < minValue)
                    {
                        result = currDigit;
                        minValue = currDigit;
                    }
                }

                return result;
            };


            Console.WriteLine(smallestNumber(arrayOfDigits));
        }
    }
}