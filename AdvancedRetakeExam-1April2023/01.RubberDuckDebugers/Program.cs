namespace _01.RubberDuckDebugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> programmersTime = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> tasks = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int dartVaderCount = 0;
            int thorCount = 0;
            int bigBlueCount = 0;
            int smallYewollCount = 0;
            while (programmersTime.Any() && tasks.Any())
            {
                int timeToMultiply = programmersTime.Dequeue();
                int taskToMultiply = tasks.Pop();
                int time = timeToMultiply * taskToMultiply;
                if (time >= 0 && time <= 60)
                {
                    dartVaderCount++;
                }
                else if (time >= 61 && time <= 120)
                {
                    thorCount++;
                }
                else if (time >= 121 && time <= 180)
                {
                    bigBlueCount++;
                }
                else if (time >= 181 && time <= 240)
                {
                    smallYewollCount++;
                }
                else if (time >= 240)
                {

                    int taskValue = taskToMultiply - 2;
                    tasks.Push(taskValue);
                    programmersTime.Enqueue(timeToMultiply);

                }
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {dartVaderCount}");
            Console.WriteLine($"Thor Ducky: {thorCount}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueCount}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYewollCount}");
        }
    }
}