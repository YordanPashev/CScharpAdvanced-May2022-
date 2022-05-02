using System;
using System.Linq;
using System.Collections.Generic;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dataBase = new Dictionary<string, Dictionary<string, int>>();

            int numebrOfLines = int.Parse(Console.ReadLine());

            FillWardrobe(dataBase, numebrOfLines);

            string[] itemToCheckSpec = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            DisplayAllClothesByColor(dataBase, itemToCheckSpec);
        }

        private static void FillWardrobe(Dictionary<string, Dictionary<string, int>> dataBase, int numebrOfLines)
        {
            for (int i = 0; i < numebrOfLines; i++)
            {
                string[] currLineInfo = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string color = currLineInfo[0];
                string[] clothesInCurrColor = currLineInfo[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!dataBase.ContainsKey(color))
                {
                    dataBase.Add(color, new Dictionary<string, int>());
                }

                foreach (string item in clothesInCurrColor)
                {
                    if (!dataBase[color].ContainsKey(item))
                    {
                        dataBase[color].Add(item, 0);
                    }

                    dataBase[color][item]++;
                }
            }
        }

        private static void DisplayAllClothesByColor(Dictionary<string, Dictionary<string, int>> dataBase, string[] itemToCheckSpec)
        {
            string colorToChek = itemToCheckSpec[0];
            string itemToCkeck = itemToCheckSpec[1];

            foreach (var color in dataBase)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (colorToChek == color.Key && itemToCkeck == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}
