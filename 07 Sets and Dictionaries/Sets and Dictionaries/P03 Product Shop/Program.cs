using System;
using System.Collections.Generic;

namespace P03_Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, double>> shop = new SortedDictionary<string, Dictionary<string, double>>();

            while (command != "Revision")
            {
                string[] tokens = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (shop.ContainsKey(tokens[0]) == false)
                {
                    shop[tokens[0]] = new Dictionary<string, double>();
                }

                shop[tokens[0]].Add(tokens[1], double.Parse(tokens[2]));


                command = Console.ReadLine();
            }

            foreach (var item in shop)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
        
    }
}
