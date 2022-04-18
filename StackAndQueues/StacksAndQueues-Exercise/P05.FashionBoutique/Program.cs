using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> boxOfClothes = new Stack<int>(clothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCounter = 1;
            int currClotherNumberOnRack = 0;

            while (boxOfClothes.Count > 0)
            {
                if (currClotherNumberOnRack + boxOfClothes.Peek() > rackCapacity)
                {
                    rackCounter++;
                    currClotherNumberOnRack = 0;
                    currClotherNumberOnRack += boxOfClothes.Pop();
                }
                else
                {
                    currClotherNumberOnRack += boxOfClothes.Pop();
                }
            }
                Console.WriteLine(rackCounter);
        }
    }
}
