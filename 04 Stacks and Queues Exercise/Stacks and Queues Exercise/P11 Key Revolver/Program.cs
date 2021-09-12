using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeGun = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int valueIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullets = new Stack<int>(bullets);
            Queue<int> queueLocks = new Queue<int>(locks);

            int count = 0;
            int useBullets = 0;
            while (stackBullets.Count > 0 && queueLocks.Count > 0)
            {
                if (stackBullets.Peek() <= queueLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    stackBullets.Pop();
                    queueLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackBullets.Pop();
                }

                count++;

                if (count == sizeGun && stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
                useBullets++;
            }

            if (stackBullets.Count >= 0 && queueLocks.Count == 0)
            {
                int earned = valueIntelligence - (useBullets * priceBullet);
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${earned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }

        }
    }
}
