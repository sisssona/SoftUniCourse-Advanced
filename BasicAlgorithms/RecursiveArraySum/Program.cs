namespace RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Console.WriteLine(RecursiveSum(list, 0));
            int RecursiveSum(List<int> list, int index) 
            {
                if (list.Count-1 == index)
                {
                    return list[index];
                }
                //pre-actions
                //recursion
                //postaction
                return list[index] + RecursiveSum(list, index + 1);
            }
        }
    }
}