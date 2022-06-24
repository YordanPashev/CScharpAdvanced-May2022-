using System;
using System.Linq;

namespace SetCover
{
    using System.Collections.Generic;
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine()
                  .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(x => int.Parse(x))
                  .ToArray();

            int numberOfRows = int.Parse(Console.ReadLine());
            int[][] sets = new int[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                int[] currRowElements = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
                sets[row] = new int[currRowElements.Length];
                for (int col = 0; col < currRowElements.Length; col++)
                {
                    int elementIndex = col;
                    sets[row][col] = currRowElements[elementIndex];
                }
            }


            List<int[]> result = ChooseSets(sets.ToList(), universe.ToList());

            Console.WriteLine($"Sets to take ({result.Count}):");
            foreach (int[] elementsInCurrRow in result)
            {
                Console.Write("{ ");
                Console.Write(string.Join(", ", elementsInCurrRow));
                Console.Write(" }");
                Console.WriteLine();

            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> result = new List<int[]>();
            while (universe.Count > 0)
            {
                int[] longestSet = sets.OrderByDescending(s => s.Count(x => universe.Contains(x)))
                       .FirstOrDefault();
                result.Add(longestSet);

                foreach (int element in longestSet)
                {
                    universe.Remove(element);
                }
            }

            return result;
        }
    }
}
