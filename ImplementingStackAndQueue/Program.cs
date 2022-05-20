using System;
using System.Collections.Generic;

namespace CustomDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            queue.Dequeue();

            queue.Peek();

            queue.Clear();

            queue.Enqueue(2);

            queue.Enqueue(1);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            queue.ForEach(x => Console.WriteLine(x));          
        }
    }
}
