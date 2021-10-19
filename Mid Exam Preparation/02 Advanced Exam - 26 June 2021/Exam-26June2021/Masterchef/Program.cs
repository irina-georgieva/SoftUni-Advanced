using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> freshValue = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<int, string> freshLevel = new Dictionary<int, string>();
            freshLevel[150] = "Dipping sauce";
            freshLevel[250] = "Green salad";
            freshLevel[300] = "Chocolate cake";
            freshLevel[400] = "Lobster";

            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>();
            dishes["Dipping sauce"] = 0;
            dishes["Green salad"] = 0;
            dishes["Chocolate cake"] = 0;
            dishes["Lobster"] = 0;

            while (ingredients.Count > 0 && freshValue.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFreshValue = freshValue.Pop();
                int totalFreshnes = currentIngredient * currentFreshValue;

                if (freshLevel.ContainsKey(totalFreshnes))
                {
                    dishes[freshLevel[totalFreshnes]]++;
                }
                else
                {
                    currentIngredient += 5;
                    ingredients.Enqueue(currentIngredient);
                }
            }

            if (dishes.Any(d => d.Value == 0))
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.Where(d => d.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
    }
}
