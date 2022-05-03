using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> candidatesResult = new SortedDictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contests = new Dictionary<string, string>();

            GetAllContests(contests);

            CollectAllCandidateResult(candidatesResult, contests);

            DisplayAllCandidatesResults(candidatesResult);
        }
        private static void GetAllContests(Dictionary<string, string> contests)
        {
            string currContest;
            while ((currContest = Console.ReadLine()) != "end of contests")
            {
                string[] currContestInfo = currContest
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contestName = currContestInfo[0];
                string password = currContestInfo[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, password);
                }
            }
        }

        private static void CollectAllCandidateResult(SortedDictionary<string, Dictionary<string, int>> candidatesResult, Dictionary<string, string> contests)
        {
            string cmd;
            while ((cmd = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdArgs = cmd
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currContest = cmdArgs[0];
                string password = cmdArgs[1];
                string userName = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (contests.ContainsKey(currContest) && contests[currContest] == password)
                {
                    if (!candidatesResult.ContainsKey(userName))
                    {
                        Dictionary<string, int> currCandidateContestResult = new Dictionary<string, int>()
                        {
                            { currContest, points }
                        };
                        candidatesResult.Add(userName, currCandidateContestResult);
                    }

                    else if (!candidatesResult[userName].ContainsKey(currContest))
                    {
                        candidatesResult[userName].Add(currContest, points);
                    }

                    else if (candidatesResult[userName][currContest] < points)
                    {
                        candidatesResult[userName][currContest] = points;
                    }
                }
            }
        }


        private static void DisplayAllCandidatesResults(SortedDictionary<string, Dictionary<string, int>> candidatesResult)
        {
            Dictionary<string, Dictionary<string, int>> bestCandidate = candidatesResult
                .OrderByDescending(c => c.Value.Values.Sum())
                .ToDictionary(c => c.Key, c => c.Value);

            Console.WriteLine($"Best candidate is {bestCandidate.First().Key} with total {bestCandidate.First().Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var candidate in candidatesResult)
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

    }
}
