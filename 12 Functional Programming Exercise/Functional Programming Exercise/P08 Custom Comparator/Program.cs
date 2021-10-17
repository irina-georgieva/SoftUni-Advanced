﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int, int> comparator = (number1, number2) =>
            (number1 % 2 == 0 && number2 % 2 != 0) ? -1 :
            (number1 % 2 != 0 && number2 % 2 == 0) ? 1 :
             number1.CompareTo(number2);

            Array.Sort<int>(numbers, new Comparison<int>(comparator));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
