using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Reverse()
                .ToList();

            int devider = int.Parse(Console.ReadLine());

            Func<int, int, bool> checkIfIsDivisble = (x,devider) => x % devider != 0;
            numbers = numbers.Where(x => checkIfIsDivisble(x, devider)).ToList();

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
