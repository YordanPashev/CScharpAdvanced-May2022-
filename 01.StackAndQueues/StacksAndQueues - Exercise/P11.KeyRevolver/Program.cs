using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsValues = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();
            int[] locksValues = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();
            int itelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsValues);
            Queue<int> locks = new Queue<int>(locksValues);
            int bulletCounter = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }

                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                bulletCounter++;

                if (bullets.Count > 0 &&
                    bulletCounter == sizeOfTheGunBarrel)
                {
                    bulletCounter = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                int bulletsLeft = bullets.Count();
                int moneyEarned = itelligenceValue - (pricePerBullet * (bulletsValues.Length - bullets.Count()));
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }

            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
            }
        }
    }
}
