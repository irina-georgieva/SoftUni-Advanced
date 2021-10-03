using System;
using System.Collections.Generic;
using System.Linq;


namespace P03_Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> upperLetterWords = new List<string> ( words.Where(word => char.IsUpper(word[0])) );

            foreach (var word in upperLetterWords)
            {
                Console.WriteLine(word);
            }
        
        }
    }
}
