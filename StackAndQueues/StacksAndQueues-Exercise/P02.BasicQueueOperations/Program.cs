using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] cmdArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int enqueueCount = cmdArgs[0];
            int dequeueCount = cmdArgs[1];
            int digitToCHeck = cmdArgs[2];

            int[] numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(x => int.Parse(x))
              .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < enqueueCount; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();

                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (queue.Contains(digitToCHeck))
            {
                Console.WriteLine($"true");
            }

            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}


