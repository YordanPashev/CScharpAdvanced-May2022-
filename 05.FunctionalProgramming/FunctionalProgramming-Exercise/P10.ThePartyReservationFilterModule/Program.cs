using System;
using System.Linq;
using System.Collections.Generic;

namespace P10.ThePartyReservationFilterModule

{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Print")
            {
                string[] cmdArgs = cmd
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];
                string criteria = cmdArgs[1];
                string criteriaValue = cmdArgs[2];

                if (action == "Add filter")
                {
                    filters.Add(criteria + criteriaValue, Createpredicate(criteria, criteriaValue));
                }

                else if (action == "Remove filter")
                {
                    filters.Remove(criteria + criteriaValue);
                }
            }

            foreach (var filter in filters)
            {
                guests.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", guests));

        }

        private static Predicate<string> Createpredicate(string criteria, string criteriaValue)
        {
            if (criteria == "Starts with")
            {
                return x => x.StartsWith(criteriaValue);
            }

            else if (criteria == "Ends with")
            {
                return x => x.EndsWith(criteriaValue);
            }

            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(criteriaValue);
            }

            else
            {
                return x => x.Contains(criteriaValue);
            }
        }
    }
}

