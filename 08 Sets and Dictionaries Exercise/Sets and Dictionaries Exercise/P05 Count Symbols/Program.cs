using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> counter = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!counter.ContainsKey(text[i]))
                {
                    counter.Add(text[i], 1);
                }
                else
                {
                    counter[text[i]] += 1;
                }
            }            

            foreach (var item in counter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
