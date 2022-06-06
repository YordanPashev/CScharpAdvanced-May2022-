using System;
using System.Collections.Generic;

namespace P05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (char currSymbol in input)
            {
                if (!symbols.ContainsKey(currSymbol))
                {
                    symbols.Add(currSymbol, 0);
                }

                symbols[currSymbol]++;
            }

            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
