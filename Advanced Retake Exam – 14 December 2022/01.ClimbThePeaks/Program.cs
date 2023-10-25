namespace _01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> foodPortions = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> dailyStamina = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> peaksToClimb = new Dictionary<string, int>()
            {
                 { "Vihren", 80},
                { "Kutelo", 90},
                { "Banski Suhodol", 100},
                { "Polezhan", 60},
                { "Kamenitza", 70}
            };
            Queue<string> peaks = new Queue<string>();
            Queue<string> conquered = new Queue<string>();
            foreach (string peak in peaksToClimb.Keys)
            {
                peaks.Enqueue(peak);
            }
            int sum = 0;
            bool ispeaksToClimb = false;
            while (foodPortions.Any() && dailyStamina.Any() && peaks.Any())
            {
                sum = foodPortions.Peek() + dailyStamina.Peek();

                if (sum >= peaksToClimb[peaks.Peek()])
                {
                    conquered.Enqueue(peaks.Dequeue());
                    foodPortions.Pop();
                    dailyStamina.Dequeue();
                    ispeaksToClimb = true;
                }             
                else
                {
                    foodPortions.Pop();
                    dailyStamina.Dequeue();
                }

            }
            if (!ispeaksToClimb)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }
            else
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            if (conquered.Any())
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in peaksToClimb)
                {
                    Console.WriteLine(peak.Key);
                }
            }
        }
    }
}