using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

           Queue<string> queueOfSongs = new Queue<string>(songs);
            string cmd = Console.ReadLine();

            while (queueOfSongs.Count > 0)
            {
                string[] cmdArgs= cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "Play")
                {
                    queueOfSongs.Dequeue();
                }

                else if (action == "Add")
                {
                    string currSong = cmd.Substring(4);

                    if (queueOfSongs.Contains(currSong))
                    {
                        Console.WriteLine($"{currSong} is already contained!");
                        cmd = Console.ReadLine();
                        continue;
                    }

                    queueOfSongs.Enqueue(currSong);
                }

                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueOfSongs));
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
