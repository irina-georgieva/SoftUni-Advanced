using System;
using System.Collections.Generic;
using System.Linq;

namespace P05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> shop = new Stack<int>(clothes);

            int sumValue = 0;
            int counterRacks = 1;

            while (shop.Count > 0)
            {
                int currentValue = sumValue + shop.Peek();

                if (currentValue <= rackCapacity)
                {
                    sumValue += shop.Pop();
                }
                else
                {
                    counterRacks++;
                    sumValue = 0;
                }
            }

            Console.WriteLine(counterRacks);
        }
    }
}
