using System;
using System.Collections.Generic;

namespace P08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarToPass= int.Parse(Console.ReadLine());
            Queue<string> carsOnTheLine = new Queue<string>();
            int passedCount = 0;
            string cmd;

            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 1; i <= numberOfCarToPass; i++)
                    {
                        if (carsOnTheLine.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{carsOnTheLine.Dequeue()} passed!");
                        passedCount++;
                    }
                }

                else
                {
                    string car = cmd;
                    carsOnTheLine.Enqueue(car);
                }
            }

            Console.WriteLine($"{passedCount} cars passed the crossroads.");
        }
    }
}
