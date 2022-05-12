using System;
using System.Linq;

namespace P11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minLettersPoints = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, int, bool> checkPoints = (name, sum) =>
            {
                return name.Sum(x => x) >= minLettersPoints;
            };

            Func<string[], Func<string, int, bool>, string> mainFunction = (names, func) => names.Where(func).FirstOrDefault();

            string result = mainFunction(names, checkPoints);

            Console.WriteLine(result);
        }
    }
}
