using System;

namespace CustomDoublyLinkList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkList<int> list = new();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            DoublyLinkList<string> listString = new();

            listString.AddFirst("some");
            listString.AddFirst("random");
            listString.AddFirst("string");

            foreach (var item in listString)
            {
                Console.WriteLine(item);
            }
        }
    }
}