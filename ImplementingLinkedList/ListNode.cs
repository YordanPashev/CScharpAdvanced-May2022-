using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(int value)
            {
                this.Value = value;
            }
            public int Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }

        }
        
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }

            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                this.tail = this.head = new ListNode(element);
            }

            else if (this.Count > 0)
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }
        
        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The List is empty!");
            }

            int firstElement = this.head.Value;
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

        public int RemoveLast()
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
        
        public void ForEach(Action<int> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];

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
