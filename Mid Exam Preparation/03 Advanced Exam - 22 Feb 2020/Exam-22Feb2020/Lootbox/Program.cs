using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersOne = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbersTwo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> boxOne = new Queue<int>(numbersOne);
            Stack<int> boxTwo = new Stack<int>(numbersTwo);

            List<int> claimedItems = new List<int>();

            while (boxOne.Count > 0 && boxTwo.Count > 0)
            {
                int itemBoxOne = boxOne.Peek();
                int itemBoxTwo = boxTwo.Pop();
                int summedItem = itemBoxOne + itemBoxTwo;

                if (summedItem % 2 == 0)
                {
                    claimedItems.Add(summedItem);
                    boxOne.Dequeue();
                }
                else
                {
                    boxOne.Enqueue(itemBoxTwo);
                }
            }

            if (boxOne.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (boxTwo.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
