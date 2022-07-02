using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] digits = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            List<int> result = new List<int>();

            foreach (var digit in digits)
            {
                queue.Enqueue(digit);
            }

            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    result.Add(queue.Peek());
                }

                queue.Dequeue();
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
