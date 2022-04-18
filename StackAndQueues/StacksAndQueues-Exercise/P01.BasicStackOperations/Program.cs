using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int[] cmdArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int pushCount = cmdArgs[0];
            int popCount = cmdArgs[1];
            int digitToCHeck = cmdArgs[2];

            int[] numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(x => int.Parse(x))
              .ToArray();

            for (int i = 0; i < pushCount; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();

                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (stack.Contains(digitToCHeck))
            {
                Console.WriteLine($"true");
            }

            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
