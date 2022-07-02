using System;
using System.Linq;

namespace P02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);

            int[] arrayofNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Console.WriteLine(arrayofNumbers.Length);
            Console.WriteLine(arrayofNumbers.Sum());
        }
    }
}
