using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int action = int.Parse(cmdArgs[0]);

                if (action == 1)
                {
                    string stringToAppend = cmdArgs[1]; 
                    result.Append(stringToAppend);
                    stack.Push(result.ToString());
                }

                else if (action == 2)
                {
                    int count = int.Parse(cmdArgs[1]);
                    int startIndex = result.Length - count;
                    result.Remove(startIndex, count);
                    stack.Push(result.ToString());
                }

                else if (action == 3)
                {
                    int index = int.Parse(cmdArgs[1]);
                    Console.WriteLine(result[index - 1]);
                }

                else if (action == 4)
                {
                    stack.Pop();
                    result.Clear();
                    if (stack.Count > 0)
                    {
                        result.Append(stack.Peek());
                    }
                }
            }
        }
    }
}
