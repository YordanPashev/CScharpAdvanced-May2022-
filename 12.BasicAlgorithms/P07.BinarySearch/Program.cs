using System;
using System.Linq;

namespace P07.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int element = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch.IndexOf(arr, element));
        }

        private class BinarySearch
        {
            public static int IndexOf(int[] arr, int element)
            {
                int low = 0;
                int high = arr.Length - 1;

                while (low <= high)
                {
                    int middle = (low + high) / 2;

                    if (element > arr[middle])
                    {
                        low = middle + 1;
                    }

                    else if (element < arr[middle])
                    {
                        high = middle - 1;
                    }


                    else if (arr[middle] == element)
                    {
                        return middle;
                    }
                }

                return -1;
            }
        }
    }
}
