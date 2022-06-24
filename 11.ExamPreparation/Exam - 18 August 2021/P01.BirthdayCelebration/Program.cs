using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> guests = new List<int>(firstInput);
            Stack<int> plates = new Stack<int>(secondInput);
            int wastedGramsOfFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int guestIndex = 0;

                if (plates.Peek() - guests[guestIndex] >= 0)
                {
                    wastedGramsOfFood += plates.Pop() - guests[guestIndex];
                    guests.RemoveAt(guestIndex);
                }

                else
                {
                    guests[guestIndex] = guests[guestIndex] - plates.Pop();
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");

            }

            else if(plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedGramsOfFood}");
        }
    }
}
