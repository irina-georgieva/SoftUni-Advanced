using System;
using System.Linq;

namespace P07_Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> nameLength = (name, length)
                => name.Length <= length;

            int maxLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split()
                .Where(x => nameLength(x, maxLength)).ToArray();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
