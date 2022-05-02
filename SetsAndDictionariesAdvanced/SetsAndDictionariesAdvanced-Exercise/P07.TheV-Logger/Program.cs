using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TheV_Logger
{
    internal class Program
    {
        class Vlogger
        {
            public Vlogger()
            {
                this.Followers = new SortedSet<string>();
                this.Following = 0;
            }
            public SortedSet<string> Followers { get; set; } = new SortedSet<string>();
            public int Following  { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> dataBase = new Dictionary<string, Vlogger>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[1];
                string vlogger = cmdArgs[0];

                if (action == "joined")
                {
                    TryToAddUserToDataBase(dataBase, vlogger);
                }

                else if (action == "followed")
                {
                    string vloggerToFollow = cmdArgs[2];
                    TryToFollow(dataBase, vlogger, vloggerToFollow);
                }
            }

            DisplayAllVlogersInfo(dataBase);
        }

        private static void DisplayAllVlogersInfo(Dictionary<string, Vlogger> dataBase)
        {
            int place = 1;
            foreach (var vlogger in dataBase.OrderByDescending(v => v.Value.Followers.Count).ThenBy(v => v.Value.Following))
            {
                if (place == 1)
                {
                    Console.WriteLine($"{place}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following} following");

                    foreach (var follower in vlogger.Value.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                else
                {
                    Console.WriteLine($"{place}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following} following");
                }

                place++;
            }
           



        }

        private static void TryToFollow(Dictionary<string, Vlogger> dataBase, string vlogger, string vloggerToFollow)
        {
            if (!dataBase.ContainsKey(vloggerToFollow) || !dataBase.ContainsKey(vlogger) ||
                vloggerToFollow == vlogger || dataBase[vloggerToFollow].Followers.Contains(vlogger))
            {
                return;
            }

            else
            {
                dataBase[vloggerToFollow].Followers.Add(vlogger);
                dataBase[vlogger].Following++;
            }
        }

        private static void TryToAddUserToDataBase(Dictionary<string, Vlogger> dataBase, string vlogger)
        {
            if (!dataBase.ContainsKey(vlogger))
            {
                Vlogger vloggerInfo = new Vlogger();
                dataBase.Add(vlogger, vloggerInfo);
            }
        }
    }
}
