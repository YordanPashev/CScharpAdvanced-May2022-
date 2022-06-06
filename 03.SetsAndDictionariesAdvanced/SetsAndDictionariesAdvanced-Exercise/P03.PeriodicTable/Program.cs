using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> uniqueElements = new SortedSet<string>();
            int elementsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < elementsCount; i++)
            {
                string[] elements = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();
                foreach (string compound in elements)
                {
                    uniqueElements.Add(compound);
                }
            }

            uniqueElements.ToList().ForEach(x => Console.Write(x + " "));
        }
    }
}
