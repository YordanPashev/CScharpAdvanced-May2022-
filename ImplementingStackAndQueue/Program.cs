using System;
using System.Collections.Generic;

namespace CustomDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GustomList gustonList = new GustomList();
            gustonList.Add(1);
            gustonList.Add(2);
            gustonList.Add(3);
            gustonList.Add(4);
            gustonList.Add(5);

            gustonList.RemoveAt(1);
            gustonList.Shrink();
        }
    }
}
