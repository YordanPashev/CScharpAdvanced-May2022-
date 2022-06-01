using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                List<string> cmdArgs = cmd
                     .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                     .ToList();
                string action = cmdArgs[0];

                if (action == "Push")
                {
                    List<int> newElementsToAdd = cmdArgs
                        .Skip(1)
                        .Select(x => int.Parse(x))
                        .ToList();

                    stack.Push(newElementsToAdd);
                }

                else if (action == "Pop")
                {
                    stack.Pop();
                }
            }

            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }

        }
    }
}
