using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberHats = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numberScarfs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> hats = new Stack<int>(numberHats);
            Queue<int> scarfs = new Queue<int>(numberScarfs);

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                int valueSet = currentHat + currentScarf;

                if (currentHat > currentScarf)
                {
                    hats.Pop();
                    sets.Add(valueSet);
                    scarfs.Dequeue();
                }
                else if (currentScarf > currentHat)
                {
                    hats.Pop();
                }
                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    currentHat += 1;
                    hats.Pop();
                    hats.Push(currentHat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
