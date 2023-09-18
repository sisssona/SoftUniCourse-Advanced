namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int valueToPush = values[0];
            int valueToPop = values[1];
            int lookUpValue = values[2];

            Queue<int> queque = new Queue<int>(input.Take(valueToPush));

            while (queque.Count > 0 && valueToPop > 0)
            {
                queque.Dequeue();
                valueToPop--;
            }
            if (queque.Contains(lookUpValue))
            {
                Console.WriteLine("true");
            }
            else if (queque.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queque.Min());
            }
        }
    }
}