using System;
using System.Collections.Generic;

namespace P06_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                if(command == "Paid")
                {
                    while(customers.Count != 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }

                    command = Console.ReadLine();
                    continue;
                }

                customers.Enqueue(command);

                command = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
