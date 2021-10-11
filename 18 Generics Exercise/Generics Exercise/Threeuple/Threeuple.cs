using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<Item1, Item2, Item3>
    {
        public Threeuple(Item1 first, Item2 second, Item3 third)
        {
            FirstItem = first;
            SecondItem = second;
            ThirdItem = third;
        }

        public Item1 FirstItem { get; set; }
        public Item2 SecondItem { get; set; }
        public Item3 ThirdItem { get; set; }

        public string GetItems()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }

    }
}
