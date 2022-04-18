using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsValues = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottlesValues = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsValues);
            Stack<int> bottles = new Stack<int>(bottlesValues);
            int wastedLittersOfWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currBottleQuantity = bottles.Pop(); 
                int currCupQuantity = cups.Dequeue();

                while (currCupQuantity > 0)
                {
                    if (currBottleQuantity - currCupQuantity >= 0)
                    {
                        wastedLittersOfWater += currBottleQuantity - currCupQuantity;
                        currCupQuantity -= currBottleQuantity;
                    }

                    else if (currCupQuantity - currBottleQuantity > 0)
                    {
                        currCupQuantity -= currBottleQuantity;
                        currBottleQuantity = bottles.Pop();
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine("Bottles: " + string.Join(" ", bottles));
            }

            else if (bottles.Count == 0)
            {
                Console.WriteLine("Cups: " + string.Join(" ", cups));
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
