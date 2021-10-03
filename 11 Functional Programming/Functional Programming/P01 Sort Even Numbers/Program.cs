using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
           var numbers = Console.ReadLine().Split(", ").Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
