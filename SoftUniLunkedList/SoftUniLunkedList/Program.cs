using System;

namespace SoftUniLunkedListCollection
{
    public class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedList linkedList = new SoftUniLinkedList();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            linkedList.AddFirst(0);
            linkedList.AddFirst(-1);

     

            Console.WriteLine($"Head: {linkedList.Head.Value}");
            Console.WriteLine($"Tail: {linkedList.Tail.Value}");
            linkedList.Reverse();
            linkedList.Foreach(x=> Console.WriteLine($"From Foreach: {x}"));

            int[] array = linkedList.ToArray();
            Console.WriteLine();

            //Node currentNoad = linkedList.Head;
            //while (currentNoad != null)
            //{
            //    Console.WriteLine(currentNoad.Value);
            //    currentNoad = currentNoad.Next;
            //}

            //Node head = new Node(0);
            //head.Next= new Node(1);
            //head.Next.Next= new Node(2);
            //head.Next.Next.Next= new Node(3);

        }
    }
}