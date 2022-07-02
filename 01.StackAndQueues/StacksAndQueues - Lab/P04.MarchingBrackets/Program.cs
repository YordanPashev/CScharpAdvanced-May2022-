using System;
using System.Collections.Generic;

namespace P04.MarchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> indices = new Stack<int>();

            string expression = Console.ReadLine();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indices.Push(i);
                }
                else if (expression[i] == ')')
                {
                    Console.WriteLine(expression.Substring(indices.Peek(), i + 1 - indices.Pop()));
                }
            }
        }
    }
}
