using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dataBase = new Dictionary<string, Dictionary<string, double>>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Revision")
            {
                string[] cmdArgs = cmd
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string shop = cmdArgs[0];
                string product = cmdArgs[1];
                double price = double.Parse(cmdArgs[2]);

                if (dataBase.ContainsKey(shop))
                {
                    dataBase[shop].Add(product, price);
                    continue;
                }

                Dictionary<string, double> newShopToAdd = new Dictionary<string, double>()
                {
                    { product, price }
                };

                dataBase.Add(shop, newShopToAdd);
            }

            foreach (var shop in dataBase.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: { product.Key}, Price: { product.Value}");
                }
            }
        }
    }
}
