using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
        class Program
        {
            static void Main(string[] args)
            {
                int[] setsSize = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                int firstSetCount = setsSize[0];
                int secondSetCount = setsSize[1];

                HashSet<int> firstSet = new HashSet<int>(firstSetCount);
                HashSet<int> secondSet = new HashSet<int>(secondSetCount);

                for (int i = 0; i < firstSetCount; i++)
                {
                    int digit = int.Parse(Console.ReadLine());
                    firstSet.Add(digit);
                }

                for (int i = 0; i < secondSetCount; i++)
                {
                    int digit = int.Parse(Console.ReadLine());
                    secondSet.Add(digit);
                }

                var repeatedDigits = firstSet.Intersect(secondSet);

                Console.WriteLine(string.Join(" ", repeatedDigits));
            }
        }
    }

