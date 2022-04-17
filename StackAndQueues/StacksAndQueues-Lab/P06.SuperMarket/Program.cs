using System;
using System.Collections.Generic;

namespace P06.SuperMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> currentClients = new Queue<string>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "End")
            {
                if (cmd == "Paid")
                {
                    while (currentClients.Count > 0)
                    {
                        Console.WriteLine(currentClients.Dequeue());
                    }
                }

                else
                {
                    string newCilent = cmd;
                    currentClients.Enqueue(newCilent);
                }   
            }

            Console.WriteLine($"{currentClients.Count} people remaining.");
        }
    }
}
