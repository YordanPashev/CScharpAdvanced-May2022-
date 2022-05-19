using System;
using System.Collections.Generic;

namespace CustomDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GustomList gustomList = new GustomList();
            gustomList.Add(1);
            gustomList.Add(2);
            gustomList.Add(3);
            gustomList.Add(4);
            gustomList.Add(5);

            gustomList[0] = 150;
            Console.WriteLine(gustomList[0]);
        }
    }
}
