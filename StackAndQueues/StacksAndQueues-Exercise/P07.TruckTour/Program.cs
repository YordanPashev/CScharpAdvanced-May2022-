using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();
            int currPumpFuelInLitters = 0;
            int distanceToNexPump = 0;

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] currPumpInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                currPumpFuelInLitters = currPumpInfo[0];
                distanceToNexPump = currPumpInfo[1];

                pumps.Enqueue(new int[] { currPumpFuelInLitters, distanceToNexPump });
            }

            int initialPoint = 0;

            while (true)
            {
                int currFuelInTruck = 0;
                bool isComplete = true;

                foreach (int[] item in pumps)
                {
                    int litters = item[0];
                    int distance = item[1];

                    currFuelInTruck += litters;

                    if (currFuelInTruck - distance < 0)
                    {
                        initialPoint++;
                        int[] currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        isComplete = false;
                        break;
                    }

                    currFuelInTruck -= distance;
                }

                if (isComplete)
                {
                    Console.WriteLine(initialPoint);
                    break;
                }
            }

        }
    }
}
