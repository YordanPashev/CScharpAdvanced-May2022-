using System;
using System.Linq;
using System.Collections.Generic;

namespace P07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int n = int.Parse(Console.ReadLine());      
            Queue<string> participants = new Queue<string>(names);

            while (participants.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string currKid = participants.Dequeue();
                    participants.Enqueue(currKid);
                }

                
                Console.WriteLine($"Removed {participants.Dequeue()}");
            }

            Console.WriteLine($"Last is {participants.Dequeue()}");
        }
    }
}
