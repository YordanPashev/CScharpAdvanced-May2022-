using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allMeals = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            int[] dailyCaloriesIntake = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            Dictionary<string, int> mealsCalories = new Dictionary<string, int>
            {
                {"salad", 350 },
                {"soup",  490},
                {"pasta",  680},
                {"steak",  790}
            };

            Queue<string> meals = new Queue<string>(allMeals);
            Stack<int> calories = new Stack<int>(dailyCaloriesIntake);

            int numberOfMeals = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                string mealName = meals.Dequeue();
                int currMealCal = mealsCalories[mealName];
                int leftDAilyCal = calories.Peek();

                if (leftDAilyCal - currMealCal > 0)
                {
                    calories.Pop();
                    calories.Push(Math.Abs(currMealCal - leftDAilyCal));
                }

                else
                {
                    calories.Pop();

                    if (leftDAilyCal - currMealCal < 0 && calories.Count > 0)
                    {
                        int leftCalForNextDay = currMealCal - leftDAilyCal;
                        int nexDayCal = calories.Pop();
                        calories.Push(nexDayCal - leftCalForNextDay);
                    }
                }

                numberOfMeals++;
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }

            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
