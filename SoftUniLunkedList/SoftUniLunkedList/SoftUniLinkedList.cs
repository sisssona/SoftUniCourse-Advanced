using System;

namespace SoftUniLunkedListCollection
{
    public class SoftUniLinkedList
    {
        private bool isReversed = false;
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public int Count { get; set; }
        public void Reverse()
        {
            isReversed = !isReversed;
        }
        public void AddLast(int nodeValue)
        {
            Count++;
            Node newNode = new Node(nodeValue);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
        public void AddFirst(int nodeValue)
        {
            Count++;
            Node newNode = new Node(nodeValue);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }
        public Node RemoveLast()
        {
            Node nodeToRemove = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            nodeToRemove.Next = null;

            Count--;
            return nodeToRemove;
        }
        public Node RemoveFirst()
        {
            Node nodeToRemove = Head; //node to remove is the head
            Head = Head.Next; //head becomes the next node
            Head.Previous = null; //We break the next tie. Previous head becomes null.
            nodeToRemove.Previous = null; //the new node removes the previous reference. It becomes null

            Count--;
            return nodeToRemove;
        }

        public void Foreach(Action<int> callback)
        {
            Node currNode = null;
            if (!isReversed)
            {
                currNode = Head;
            }
            else
            {
                currNode = Tail;
            }
            while (currNode != null)
            {
                callback(currNode.Value);
                if (!isReversed)
                {
                    currNode = currNode.Next;
                }
                else
                {
                    currNode = currNode.Previous;
                }

              
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;

            Foreach(n => array[index++] = n);

            //Node currNode = Head;
            //while (currNode != null)
            //{
            //    array[index++] = currNode.Value;
            //    currNode = currNode.Next;
            //}
            return array;
        }


    }


}