using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddLast(1);
            doublyLinkedList.RemoveLast();
            doublyLinkedList.RemoveFirst();
            doublyLinkedList.RemoveFirst();


            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            int[] arr = doublyLinkedList.ToArray();
        }
    }
}
