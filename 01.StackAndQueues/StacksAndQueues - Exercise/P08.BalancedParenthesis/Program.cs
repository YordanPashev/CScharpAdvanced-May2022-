using System;
using System.Collections.Generic;

namespace P08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            Stack<char> queue = new Stack<char>();

            bool isBalanced = false;

            foreach (char currSymbol in inputLine)
            {
                if (currSymbol == '(' ||
                currSymbol == '[' ||
                currSymbol == '{')
                {
                    queue.Push(currSymbol);
                    isBalanced = false;
                }

                else if (currSymbol == ')' ||
                         currSymbol == ']' ||
                         currSymbol == '}')
                {

                    if (queue.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    else if (queue.Count > 0)
                    {
                        if (currSymbol == ')' && queue.Peek() == '(')
                        {
                            queue.Pop();
                            isBalanced = true;
                        }

                        else if (currSymbol == ']' && queue.Peek() == '[')
                        {
                            queue.Pop();
                            isBalanced = true;
                        }

                        else if (currSymbol == '}' && queue.Peek() == '{')
                        {
                            queue.Pop();
                            isBalanced = true;
                        }
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }

            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
