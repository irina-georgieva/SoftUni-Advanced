using System;
using System.Collections.Generic;

namespace P04_Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] countries = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (continents.ContainsKey(countries[0]) == false)
                {
                    continents.Add(countries[0], new Dictionary<string, List<string>>());
                }

                if (continents[countries[0]].ContainsKey(countries[1]) == false)
                {
                    continents[countries[0]].Add(countries[1], new List<string>());
                }

                continents[countries[0]][countries[1]].Add(countries[2]);
            }

            foreach (var item in continents)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var country in item.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
