using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string expression = Console.ReadLine();

            int[] digits = expression
                .Split(new[] { " + ", " - "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int digit in digits)
            {
                stack.Push((int)digit);
            }
            int result = 0;

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char action = expression[i];

                if (action == '+')
                {
                    result += stack.Pop();
                }

                else if (action == '-')
                {
                    result -= stack.Pop();
                }
            }

            result += stack.Pop();
            Console.WriteLine(result);
        }
    }
}
