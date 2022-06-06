using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, string, bool> isApplyToGivenCriteria = (guest, criteria, criteriaValue) =>
            {
                if (criteria == "StartsWith")
                {
                    return guest.StartsWith(criteriaValue);
                }

                else if (criteria == "EndsWith")
                {
                    return guest.EndsWith(criteriaValue);
                }

                else
                {
                    return guest.Length == int.Parse(criteriaValue);
                }
            };
            string cmd;
            while ((cmd = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];
                string criteria = cmdArgs[1];
                string criteriaValue = cmdArgs[2];

                if (action == "Remove")
                {
                    guests.RemoveAll(g => isApplyToGivenCriteria(g, criteria, criteriaValue));
                }

                else if (action == "Double")
                {
                    TryToDobuleNamesWithGivenLength(guests, isApplyToGivenCriteria, criteria, criteriaValue);
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                Environment.Exit(0);
            }

            Console.WriteLine(string.Join(", ", guests) + " are going to the party!");

        }

        private static void TryToDobuleNamesWithGivenLength(List<string> guests, Func<string, string, string, bool> isApplyToGivenCriteria, string criteria, string criteriaValue)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                if (isApplyToGivenCriteria(guests[i], criteria, criteriaValue))
                {
                    guests.Insert(i, guests[i]);
                    i++;
                }
            }
        }
    }
}
