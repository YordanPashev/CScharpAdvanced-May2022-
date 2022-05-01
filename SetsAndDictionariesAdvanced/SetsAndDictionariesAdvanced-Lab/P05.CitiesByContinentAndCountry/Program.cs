using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> dataBase = new Dictionary<string, Dictionary<string,List<string>>>();
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] locationInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string continent = locationInfo[0];
                string country = locationInfo[1];   
                string city = locationInfo[2];

                if (!dataBase.ContainsKey(continent))
                {
                    dataBase.Add(continent, new Dictionary<string, List<string>>());
                    dataBase[continent].Add(country, new List<string>());
                }

                else if (!dataBase[continent].ContainsKey(country))
                {
                    dataBase[continent].Add(country, new List<string>());
                }

                dataBase[continent][country].Add(city);
            }

            DisplayDataBase(dataBase);
        }  
        static void DisplayDataBase(Dictionary<string, Dictionary<string, List<string>>> dataBase)
        {
            foreach (var location in dataBase)
            {
                var continent = location.Key;

                Console.WriteLine($"{continent}:");

                var countries = location.Value;

                foreach (var country in countries)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
