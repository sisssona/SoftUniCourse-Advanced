using System.Diagnostics;

namespace Algorythms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Enumerable.Range(0, 1_000_000).ToList();
            Console.WriteLine(list.Count);
            ConstantAlgorythm(list.ToHashSet());
            LogNAlgotythm(list);
            LinearTime(list);


            void ConstantAlgorythm(HashSet<int> list)
            {
                Stopwatch watch = Stopwatch.StartNew();
                bool exists = list.Contains(5000);

                watch.Stop();
                Console.WriteLine($"Constant time O(1): {watch.ElapsedMilliseconds}");
            }
            void LogNAlgotythm(List<int> list)
            {
                Stopwatch watch = Stopwatch.StartNew();
                int index = list.BinarySearch(5000);

                watch.Stop();
                Console.WriteLine($"Logn time O(logn): {watch.ElapsedMilliseconds} {index}");
            }
            void LinearTime(List<int> list)
            {
                Stopwatch watch = Stopwatch.StartNew();
                bool exist = false;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == 5000)
                    {
                        exist = true;
                    }
                }

                watch.Stop();
                Console.WriteLine($"Linear time O(n): {watch.ElapsedMilliseconds} {exist}");
            }
        }


    }
}