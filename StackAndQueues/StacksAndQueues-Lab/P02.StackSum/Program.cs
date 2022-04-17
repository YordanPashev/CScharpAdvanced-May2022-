using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (int digit in arr)
            {
                stack.Push(digit);
            }

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "add")
                {
                    AddDigits(stack, cmdArgs);

                }

                else if (action == "remove")
                {
                    int count = int.Parse(cmdArgs[1]);

                    TryToRemoveDigits(stack, count);
                }
            }

            DisplaySumOfAllDigitsLeft(stack);
        }

        static void AddDigits(Stack<int> stack, string[] cmdArgs)
        {
            int firstDigit = int.Parse(cmdArgs[1]);
            int secondDigit = int.Parse(cmdArgs[2]);
            stack.Push(firstDigit);
            stack.Push(secondDigit);
        }
        static void TryToRemoveDigits(Stack<int> stack, int count)
        {
            if (count > stack.Count)
            {
                return;
            }

            else
            {
                for (int i = 1; i <= count; i++)
                {
                    stack.Pop();
                }
            }
        }
        static void DisplaySumOfAllDigitsLeft(Stack<int> stack)
        {
            int result = 0;

            while (stack.Count > 0)
            {
                result += stack.Peek();
                stack.Pop();
            }

            Console.WriteLine($"Sum: {result}");
        }
    }
}
