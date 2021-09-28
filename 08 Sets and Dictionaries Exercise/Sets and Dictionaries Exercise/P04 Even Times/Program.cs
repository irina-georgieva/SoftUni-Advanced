using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(inputNumber))
                {
                    numbers.Add(inputNumber, 0);
                }

                numbers[inputNumber]++;
            }

            //int number = numbers.Where(x => x.Value % 2 == 0).FirstOrDefault()
            //    .Key;

            foreach (var (key, value) in numbers)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine(key);
                    break;
                }
            }

        }
    }
}
