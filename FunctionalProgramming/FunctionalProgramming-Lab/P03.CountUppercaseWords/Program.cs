using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> checkFirstLetter = w => Char.IsUpper(w[0]);
            List<string> wordsStartWithUpperCaseLeter = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => checkFirstLetter(w))
                .ToList();
           
            wordsStartWithUpperCaseLeter.ForEach(x => Console.WriteLine(x));
        }
    }
}
