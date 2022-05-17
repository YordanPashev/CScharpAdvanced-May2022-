using System;


namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.ForEach(x => Console.WriteLine(x));
        }
    }
}
