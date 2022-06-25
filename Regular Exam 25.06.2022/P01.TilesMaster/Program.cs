using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => int.Parse(x))
                                  .ToArray();

            int[] secondInput = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => int.Parse(x))
                                  .ToArray();

            Stack<int> whiteTiles = new Stack<int>(firstInput);
            Queue<int> greyTiles = new Queue<int>(secondInput);

            Dictionary<string, int> locations = new Dictionary<string, int>
            {
                {"Countertop", 0},
                {"Floor", 0},
                {"Oven", 0},
                {"Sink", 0},
                {"Wall", 0},
            };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int currFormedArea = whiteTiles.Peek() + greyTiles.Peek();

                    if (currFormedArea == 40)
                    {
                        locations["Sink"]++;
                    }

                    else if (currFormedArea == 50)
                    {
                        locations["Oven"]++;
                    }

                    else if (currFormedArea == 60)
                    {
                        locations["Countertop"]++;
                    }

                    else if (currFormedArea == 70)
                    {
                        locations["Wall"]++;
                    }

                    else
                    {
                        locations["Floor"]++;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }

                else if (whiteTiles.Peek() != greyTiles.Peek())
                {
                    int currWhiteTileArea = whiteTiles.Pop() / 2;
                    whiteTiles.Push(currWhiteTileArea);
                    int currGreyTileArea = greyTiles.Dequeue();
                    greyTiles.Enqueue(currGreyTileArea);
                }
            }

            var whiteTilesLeftResult = whiteTiles.Count > 0 ? $"White tiles left: {string.Join(", ", whiteTiles)}" :
                                                              $"White tiles left: none";

            Console.WriteLine(whiteTilesLeftResult);

            var greyTilesLeftResult = greyTiles.Count > 0 ? $"Grey tiles left: {string.Join(", ", greyTiles)}" :
                                                            $"Grey tiles left: none";

            Console.WriteLine(greyTilesLeftResult);

            foreach (var location in locations.Where(l => l.Value > 0)
                                              .OrderByDescending(l => l.Value)
                                              .ThenBy(l => l.Key)
                                              )
            {
                    Console.WriteLine($"{location.Key}: {location.Value}");        
            }
        }
    }
}
