using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> products = new Dictionary<string, int>
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette", 0},
                {"Bagel",0}
            };

            double[] firstInput = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(double.Parse)
                                  .ToArray();

            double[] secondInput = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(double.Parse)
                                 .ToArray();

            Queue<double> water = new Queue<double>(firstInput);
            Stack<double> flour = new Stack<double>(secondInput);

            while (water.Count > 0 && flour.Count > 0)
            {
                double currWaterValue = water.Dequeue();
                double currFlourValue = flour.Pop();

                double currProductsSum =  currWaterValue + currFlourValue;

                double waterPercIntCurrProduct = currWaterValue / currProductsSum * 100;
                double flourPercIntCurrProduct = currFlourValue / currProductsSum * 100;

                if (waterPercIntCurrProduct == 50 || flourPercIntCurrProduct == 50)
                {
                    products["Croissant"]++;
                }

                else if (waterPercIntCurrProduct == 40 || flourPercIntCurrProduct == 60)
                {
                    products["Muffin"]++;
                }

                else if (waterPercIntCurrProduct == 30 || flourPercIntCurrProduct == 70)
                {
                    products["Baguette"]++;
                }

                else if (waterPercIntCurrProduct == 20 || flourPercIntCurrProduct == 80)
                {
                    products["Bagel"]++;
                }

                else
                {
                    currFlourValue -= currWaterValue;

                    if (currFlourValue > 0)
                    {
                        flour.Push(currFlourValue);
                    }

                    products["Croissant"]++;
                }
            }

            foreach (var product in products
                                    .OrderByDescending(p => p.Value)
                                    .ThenBy(p => p.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: { string.Join(", ", water)}");
            }

            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: { string.Join(", ", flour)}");
            }

            else
            {
                Console.WriteLine("Flour left: None");
            }          
        }
    }
}
