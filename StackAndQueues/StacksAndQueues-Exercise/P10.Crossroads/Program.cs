using System;
using System.Collections.Generic;
using System.Text;

namespace P10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightLength = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> queueTrafficLine = new Queue<string>();
            int totalCarsPassed = 0;
            int carCounter = 0;
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int currGreenLight = greenLightLength;

                    while (currGreenLight > 0 && queueTrafficLine.Count > 0)
                    {
                        string currCar = queueTrafficLine.Dequeue();
                        if (currGreenLight - currCar.Length >= 0)
                        {
                            currGreenLight -= currCar.Length;
                            totalCarsPassed++;
                            continue;
                        }

                        if (currGreenLight + freeWindow - currCar.Length >= 0)
                        {
                            currGreenLight = 0;
                            totalCarsPassed++;
                            continue;
                        }

                        int hitPoint = currCar.Length- (currGreenLight + freeWindow);
                        hitPoint = currCar.Length - hitPoint;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currCar} was hit at {currCar[hitPoint]}.");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    queueTrafficLine.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
 