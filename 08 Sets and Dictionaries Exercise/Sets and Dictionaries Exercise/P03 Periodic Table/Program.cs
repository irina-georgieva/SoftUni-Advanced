using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> chemicalElements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elements.Length; j++)
                {
                    chemicalElements.Add(elements[j]);
                }                
            }

            var sortedElements = chemicalElements.OrderBy(x => x);

            foreach (var item in sortedElements)
            {
                Console.Write(item + " ");
            }
        }
    }
}
