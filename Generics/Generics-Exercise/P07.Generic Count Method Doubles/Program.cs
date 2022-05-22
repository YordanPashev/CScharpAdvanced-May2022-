using System;

namespace GenericCountMethodDoubles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            Box<double> boxOfString = new Box<double>();

            for (int i = 0; i < numberOfStrings; i++)
            {
                double input = double.Parse(Console.ReadLine());
                boxOfString.listOfelements.Add(input);
            }

            double elementToCompare = double.Parse(Console.ReadLine());
            int result = boxOfString.GetCompareResult(elementToCompare);

            Console.WriteLine(result);
        }
    }
}
