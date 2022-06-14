using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[] input2 = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Queue<int> bombEffects = new Queue<int>(input1);
            Stack<int> bombCasings = new Stack<int>(input2);
            int cherryBombsCount = 0;
            int daturaBobsCount = 0;
            int smokeDecoyBombsCount = 0;

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                if (bombCasings.Peek() < 0)
                {
                    bombCasings.Pop();
                }

                if (bombEffects.Peek() + bombCasings.Peek() == 40)
                {
                    daturaBobsCount++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }

                else if (bombEffects.Peek() + bombCasings.Peek() == 60)
                {
                    cherryBombsCount++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }

                else if (bombEffects.Peek() + bombCasings.Peek() == 120)
                {
                    smokeDecoyBombsCount++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }

                else
                {
                    int currBombCasingValue = bombCasings.Pop();
                    bombCasings.Push(currBombCasingValue - 5);
                }

                if ((daturaBobsCount >= 3 && cherryBombsCount >= 3 && smokeDecoyBombsCount >= 3))
                {
                    break;
                }
            }

            DisplayResults(bombEffects, bombCasings, daturaBobsCount, cherryBombsCount, smokeDecoyBombsCount);
        }

        private static void DisplayResults(Queue<int> bombEffects, Stack<int> bombCasings, int daturaBombsCount, int cherryBombsCount, int smokeDecoyBombsCount)
        {
            DisplayEzioResult(daturaBombsCount, cherryBombsCount, smokeDecoyBombsCount);

            DisplayBombsEffectsLeft(bombEffects);

            DisplayBombsCasingsLeft(bombCasings);

            Console.WriteLine($"Cherry Bombs: {cherryBombsCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombsCount}");
        }

        private static void DisplayEzioResult(int daturaBobsCount, int cherryBombsCount, int smokeDecoyBombsCount)
        {
            if (daturaBobsCount >= 3 &&
                cherryBombsCount >= 3 &&
                smokeDecoyBombsCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
        }

        private static void DisplayBombsEffectsLeft(Queue<int> bombEffects)
        {
            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
        }

        private static void DisplayBombsCasingsLeft(Stack<int> bombCasings)
        {
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
        }
    }
}
