using System;
using System.Linq;

namespace P05.Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd == "add")
                {
                    Func<int, int> add = x => x += 1;
                    numbers = numbers.Select(x => add(x)).ToArray();
                }

                else if (cmd == "multiply")
                {
                    Func<int, int> multiply = x => x *= 2;
                    numbers = numbers.Select(x => multiply(x)).ToArray();
                }

                else if (cmd == "subtract")
                {
                    Func<int, int> subtract = x => x -= 1;
                    numbers = numbers.Select(x => subtract(x)).ToArray();
                }

                else if (cmd == "print")
                {
                    Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));
                    print(numbers);
                }
            }
        }
    }
}

