using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int numberOfLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLine; i++)
            {
                string cmd = Console.ReadLine();
                
                if (cmd[0] == '1')
                {
                    int digitToAdd = int.Parse(cmd.Substring(1));
                    stack.Push(digitToAdd);
                }

                else if (cmd[0] == '2' && stack.Count > 0)
                {
                    stack.Pop();
                }

                else if (cmd[0] == '3' && stack.Count > 0)
                {
                    Console.WriteLine($"{stack.Max()}");
                }

                else if (cmd[0] == '4' && stack.Count > 0)
                {
                    Console.WriteLine($"{stack.Min()}");
                }
            }

            while (stack.Count > 1)
            {
                Console.Write(stack.Pop() + ", ");
            }

            Console.Write(stack.Pop());
        }
    }
}
