using System;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPass = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> contestSubmissions = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] passwordForContest = input.Split(":");
                string contest = passwordForContest[0];
                string password = passwordForContest[1];
                contestAndPass.Add(contest, password);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] submissions = input.Split("=>");
                string contest = submissions[0];
                string password = submissions[1];
                string user = submissions[2];
                int points = int.Parse(submissions[3]);

                //check if we have already added the contest and pass
                if (contestAndPass.ContainsKey(contest) && contestAndPass[contest] == password)
                {
                    //add user if it is not present in the new dictionary and after that add the contest he is taking part in and the points he has
                    if (!contestSubmissions.ContainsKey(user))
                    {
                        contestSubmissions.Add(user, new Dictionary<string, int>());
                        contestSubmissions[user].Add(contest, points);
                    }
                    else
                    {
                        //if the user is added but the contest he is taking part in is not - add it with the corresponding points
                        if (!contestSubmissions[user].ContainsKey(contest))
                        {
                            contestSubmissions[user].Add(contest, points);
                        }
                        //if the user and the contest are already added
                        else
                        {//if the added points for the given contest are smaller than the new replace them with the higher score
                            if (contestSubmissions[user][contest] < points)
                            {
                                contestSubmissions[user][contest] = points;
                            }
                        }
                    }
                }
            }
            int bestUserPoints = 0;
            //print
            string bestStudent = null;
            foreach (var userName in contestSubmissions)
            {
                int totalPoints = 0;
                foreach (var course in userName.Value)
                {
                    totalPoints += course.Value;
                }

                if (totalPoints > bestUserPoints)
                {
                    bestStudent = userName.Key;
                    bestUserPoints = totalPoints;
                }

            }
            Console.WriteLine($"Best candidate is {bestStudent} with total {bestUserPoints} points.");
            contestSubmissions = contestSubmissions.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Ranking:");
            foreach (var userName in contestSubmissions)
            {
                Console.WriteLine(userName.Key);
                foreach (var course in userName.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
