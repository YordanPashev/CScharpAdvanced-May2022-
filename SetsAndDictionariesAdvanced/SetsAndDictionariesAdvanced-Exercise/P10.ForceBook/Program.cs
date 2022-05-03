using System;
using System.Linq;
using System.Collections.Generic;

namespace P10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> sides = new Dictionary<string, SortedSet<string>>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] cmdArgs = cmd
                        .Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                if (cmd.Contains(" | "))
                {
                    string forceSide = cmdArgs[0];
                    string forceUser = cmdArgs[1];

                    bool IsContainsForceUser = sides.Any(x => x.Value.Contains(forceUser));

                    if (!IsContainsForceUser)
                    {
                        if (!sides.ContainsKey(forceSide))
                        {
                            sides.Add(forceSide, new SortedSet<string>() { forceUser });
                        }

                        else if (!sides[forceSide].Contains(forceUser))
                        {
                            sides[forceSide].Add(forceUser);
                        }
                    }
                }

                else if (cmd.Contains(" -> "))
                {
                    string forceUser = cmdArgs[0];
                    string forceSide = cmdArgs[1];
                    bool isContainsForceUser = sides.Any(x => x.Value.Contains(forceUser));

                    if (isContainsForceUser)
                    {
                        var currUserSide = sides.Where(x => x.Value.Contains(forceUser)).ToDictionary(x => x.Key, x => x.Value);

                        if (!sides.ContainsKey(forceSide))
                        {
                            sides.Add(forceSide, new SortedSet<string>());
                        }

                        sides[currUserSide.First().Key].Remove(forceUser);
                        sides[forceSide].Add(forceUser);
                    }
                    else
                    {
                        if (!sides.ContainsKey(forceSide))
                        {
                            sides.Add(forceSide, new SortedSet<string>());
                        }

                        sides[forceSide].Add(forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            DisplayForceSidesUsers(sides);
        }

        private static void DisplayForceSidesUsers(Dictionary<string, SortedSet<string>> sides)
        {
            foreach (var forceSide in sides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (forceSide.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");
                foreach (var forceUser in forceSide.Value)
                {
                    Console.WriteLine($"! {forceUser}");
                }
            }
        }
    }
}
