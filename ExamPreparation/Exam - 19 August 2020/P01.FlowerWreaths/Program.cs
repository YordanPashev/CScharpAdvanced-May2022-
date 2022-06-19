using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.FLowerWreath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => int.Parse(x))
                               .ToArray();

            int[] secondInput = Console.ReadLine()
                              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(x => int.Parse(x))
                              .ToArray();

            double sotredFlowers = 0;
            double wreathCount = 0;

            Stack<int> lilies = new Stack<int>(firstInput);
            Queue<int> roses = new Queue<int>(secondInput);

            while (lilies.Count > 0 && roses.Count > 0 && wreathCount < 5)
            {
                if (lilies.Peek() + roses.Peek() <= 15)
                {
                    if (lilies.Peek() + roses.Peek() == 15)
                    {
                        wreathCount++;
                    }

                    else
                    {
                        sotredFlowers += lilies.Peek() + roses.Peek(); 
                    }

                    lilies.Pop();
                    roses.Dequeue();
                }

                else
                {
                    int currLiliesVAlue = lilies.Peek() - 2;
                    lilies.Pop();
                    lilies.Push(currLiliesVAlue);
                }
            }

            wreathCount += Math.Round(Math.Floor(sotredFlowers / 15.00));

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }

            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }
    }
}
