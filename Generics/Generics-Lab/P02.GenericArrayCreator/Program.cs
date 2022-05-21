using System;
using System.Collections.Generic;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] stringArray = ArrayCreator.Create(4, "basi");
            int[] intArray = ArrayCreator.Create(3, 2);
            foreach (var item in intArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
