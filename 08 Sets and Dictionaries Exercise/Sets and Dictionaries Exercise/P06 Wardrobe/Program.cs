using System;
using System.Collections.Generic;

namespace P06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = inputArgs[0];
                string[] clothes = inputArgs[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] targetCloth = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // Dictionary<string, Dictionary<string, int>>
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var (cloth, value) in color.Value)
                {
                    if (cloth == targetCloth[1] && color.Key == targetCloth[0])
                    {
                        Console.WriteLine($"* {cloth} - {value} (found!)");

                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {value}");
                    }
                }
            }
        }
    }
}
