using System;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDoublyLinkedList<int> integers = new MyDoublyLinkedList<int>();
            integers.AddFirst(3);
            integers.AddFirst(2);
            integers.AddFirst(1);
            integers.AddFirst(15);

            Console.WriteLine(integers.RemoveFirst());

            integers.ForEach(x => Console.WriteLine(x));
        }
    }
}
