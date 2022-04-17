using System;
using System.Collections.Generic;

namespace P01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringToReverse = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach (char ch in stringToReverse)
            {
                stack.Push(ch);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
