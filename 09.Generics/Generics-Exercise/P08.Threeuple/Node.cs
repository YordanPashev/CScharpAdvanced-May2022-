using System;

namespace CustomDoublyLinkedList
{
    public class MyDoublyLinkedList<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }

            public Node NextNode { get; set; }

            public Node PreviousNode { get; set; }

        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node(element);
            }

            else
            {
                var newHead = new Node(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }

        public void AddLast(T element)
        {
            if (Count == 0)
            {
                this.tail = this.head = new Node(element);
            }

            else if (this.Count > 0)
            {
                var newTail = new Node(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The List is empty!");
            }

            T firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }

            else
            {
                this.tail = null;
            }

            Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The List is empty!");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }

            else
            {
                this.head = null;
            }

            Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            var currNode = this.head;
            int index = 0;
            while (currNode != null)
            {
                array[index] = currNode.Value;
                currNode = currNode.NextNode;
                index++;
            }

            return array;
        }
    }
}