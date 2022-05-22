using System;
using System.Linq;

namespace GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            
            Box<string> boxOfString = new Box<string>();

            for (int i = 0; i < numberOfStrings; i++)
            {
                string input = Console.ReadLine();
                boxOfString.listOfStrings.Add(input);
            }

            int[] indicies = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int firstIndex = indicies[0];
            int secondIndex = indicies[1];

            boxOfString.SwapTwoElements(firstIndex, secondIndex);

            boxOfString.Print();
        }
    }
}
