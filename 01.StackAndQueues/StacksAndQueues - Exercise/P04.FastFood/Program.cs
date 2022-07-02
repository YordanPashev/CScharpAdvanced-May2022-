using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int currNumberOforders = int.Parse(Console.ReadLine());

               int[] orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (currNumberOforders - queue.Peek() < 0 )
                {
                    break;
                }

                currNumberOforders -= queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine($"Orders complete");
            }

            else
            {
                Console.WriteLine("Orders left: " + string.Join(" ", queue));
            }
        }
    }
}
