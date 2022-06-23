using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int result = SumArrayElements(array, array.Length - 1);
            Console.WriteLine(result);
        }

        public static int SumArrayElements(int[] array, int index)
        {
            if (index == 0)
            {
                return array[index];
            }

            return array[index] + SumArrayElements(array, index - 1);
        }
    }
}
