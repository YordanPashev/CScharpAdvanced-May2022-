using System;
using System.Linq;
using System.Collections.Generic;

namespace P09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languageData = new Dictionary<string, int>();
            Dictionary<string, int> usersData = new Dictionary<string, int>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "exam finished")
            {
                ExecuteCommand(usersData, languageData, cmd);
            }

            DisplayResults(usersData, languageData);
        }

        static void ExecuteCommand(Dictionary<string, int> usersData, Dictionary<string, int> languageData, string cmd)
        {
            string[] cmdArgs = cmd
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

            string username = cmdArgs[0];
            string action = cmdArgs[1];

            if (action == "banned")
            {
                usersData.Remove(username);
                return;
            }

            string language = cmdArgs[1];
            int points = int.Parse(cmdArgs[2]);

            if (!languageData.ContainsKey(language))
            {
                languageData.Add(language, 0);
            }

            if (!usersData.ContainsKey(username))
            {
                usersData.Add(username, points);
            }

            else if (usersData[username] < points)
            {
                usersData[username] = points;
            }

            languageData[language]++;
        }
        private static void DisplayResults(Dictionary<string, int> usersData, Dictionary<string, int> languageData)
        {
            Console.WriteLine("Results:");
            foreach (var user in usersData.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine($"Submissions:");
            foreach (var language in languageData.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
