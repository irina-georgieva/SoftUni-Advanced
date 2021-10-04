using System;
using System.Collections.Generic;
using System.Linq;

namespace P12_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> isLargerOrEqual = (name, asciSum)
                => name.Sum(x => x) >= asciSum;

            Func<List<string>, int, Func<string, int, bool>, string> desiredName 
                = (allNames, number, func)
                => allNames.FirstOrDefault(x => func(x, number));

            string name = desiredName(names, n, isLargerOrEqual);

            Console.WriteLine(name);
        }
    }
}
