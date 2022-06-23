using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BlackSmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> swords = new SortedDictionary<string, int> 
            {
                {"Gladius", 0},
                {"Shamshir", 0},
                {"Katana", 0},
                {"Sabre", 0},
                {"Broadsword", 0}
            };

            int[] firstInput = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => int.Parse(x))
                               .ToArray();

            int[] secondInput = Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(x => int.Parse(x))
                       .ToArray();

            Queue<int> steel = new Queue<int>(firstInput);
            Stack<int> carbon = new Stack<int>(secondInput);

            while (steel.Count > 0 && carbon.Count > 0)
            {
                TryToForge(swords, carbon, steel);
            }

            DisplayResults(swords, steel, carbon);
        }

        private static void TryToForge(SortedDictionary<string, int> swords, Stack<int> carbon, Queue<int> steel)
        {
            int currSteelValue = steel.Dequeue();
            int currCarbonValue = carbon.Pop();
            int sum = currSteelValue + currCarbonValue;

            switch (sum)
            {
                case 70:
                    swords["Gladius"]++;
                    break;
                case 80:
                    swords["Shamshir"]++;
                    break;
                case 90:
                    swords["Katana"]++;
                    break;
                case 110:
                    swords["Sabre"]++;
                    break;
                case 150:
                    swords["Broadsword"]++;
                    break;
                default:
                    currCarbonValue += 5;
                    carbon.Push(currCarbonValue);
                    break;
            }
        }

        private static void DisplayResults(SortedDictionary<string, int> swords, Queue<int> steel, Stack<int> carbon)
        {
            string swordsCountResult = swords.Values.Any(c => c > 0) ? $"You have forged {swords.Values.Sum()} swords." :
                                                                    "You did not have enough resources to forge a sword.";

            Console.WriteLine(swordsCountResult);


            string steelleftResult = steel.Count == 0 ? "Steel left: none" : $"Steel left: {string.Join(", ",  steel)}";

            Console.WriteLine(steelleftResult);

            string carbonleftResult = carbon.Count == 0 ? "Carbon left: none" : $"Carbon left: {string.Join(", ", carbon)}";

            Console.WriteLine(carbonleftResult);

            foreach (KeyValuePair<string, int> sword in swords)
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
