using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int mealsCount = 0;
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>()
            {
                {"salad",350 },
                {"soup",490 },
                {"pasta",680 },
                {"steak",790 },
            };
            while (true)
            {
                if (!meals.Any() || !calories.Any())
                {
                    break;
                }
                string currentMeal = meals.Peek();
                int currCaloriesIntake = calories.Peek();
                int leftCalories = 0;
                int nextDayCalories = 0;
                if (mealsCalories.ContainsKey(currentMeal))
                {
                    currCaloriesIntake -= mealsCalories[currentMeal];
                    calories.Pop();
                    calories.Push(currCaloriesIntake);
                    meals.Dequeue();
                    mealsCount++;
                    if (currCaloriesIntake == 0)
                    {
                        calories.Pop();
                    }
                    if (currCaloriesIntake < 0)
                    {
                        leftCalories = Math.Abs(currCaloriesIntake);
                        calories.Pop();
                        if (calories.Any())
                        {

                            nextDayCalories = calories.Peek();
                            nextDayCalories -= leftCalories;
                            calories.Pop();
                            calories.Push(nextDayCalories);
                        }

                    }
                }
            }
            if (!meals.Any() && calories.Any())
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                foreach (var item in calories)
                {
                    Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
                    break;
                }
            }
            if (meals.Any())
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                foreach (var item in meals)
                {
                    Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
                    break;
                }

            }

        }
    }
}
