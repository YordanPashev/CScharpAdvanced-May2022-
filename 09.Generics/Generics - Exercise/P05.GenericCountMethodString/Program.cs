using System;
using System.Linq;

namespace GenericCountMethodString
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
                boxOfString.listOfelements.Add(input);
            }

            string elementToCompare = Console.ReadLine();
            int result = boxOfString.GetCompareResult(elementToCompare);

            Console.WriteLine(result);
        }
    }
}
