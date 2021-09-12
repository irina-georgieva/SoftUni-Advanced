using System;
using System.Collections.Generic;
using System.Linq;

namespace P12_CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] bottlesCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int wastedWater = 0;

            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(bottlesCapacity);

            while (cups.Count != 0 && bottles.Count != 0)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();                    
                }
                else if(cups.Peek() > bottles.Peek())
                {
                    int currentCup = cups.Dequeue();
                    while (currentCup > 0)
                    {
                        if (currentCup >= bottles.Peek())
                        {
                            currentCup -= bottles.Pop();
                        }
                        else if (currentCup < bottles.Peek())
                        {
                            wastedWater += bottles.Pop() - currentCup;
                            currentCup = 0;
                        }                                                
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if(bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");        
        }
    }
}
