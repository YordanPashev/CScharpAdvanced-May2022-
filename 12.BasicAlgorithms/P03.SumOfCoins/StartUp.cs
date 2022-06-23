using System;
using System.Linq;

namespace SumOfCoins
{
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] availabeCoins = Console.ReadLine()
                                  .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            int desirebleSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> neededCoins = ChooseCoins(availabeCoins, desirebleSum);

            Console.WriteLine($"Number of coins to take: {neededCoins.Values.Sum()}");
            foreach (var coin in neededCoins.Where(c => c.Value != 0))
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            List<int> listOfAvailableCoins = coins.OrderByDescending(c => c).ToList();
            Dictionary<int, int> neededCoins = new Dictionary<int, int>();

            foreach (var coin in listOfAvailableCoins)
            {
                neededCoins.Add(coin, 0);
            }


            foreach (var coin in listOfAvailableCoins)
            {
                while (coin <= targetSum)
                {
                    neededCoins[coin]++;
                    targetSum -= coin;
                }
            }

            if (targetSum == 0)
            {
                return neededCoins;
            }

            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}