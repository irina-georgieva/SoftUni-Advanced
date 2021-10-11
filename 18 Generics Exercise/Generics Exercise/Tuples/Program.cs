using System;

namespace Tuple
{
    class StartUp   
    {
        static void Main(string[] args)
        {
            string[] nameTownInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = $"{nameTownInput[0]} {nameTownInput[1]}";
            string town = nameTownInput[2];


            string[] nameBeerInput = Console.ReadLine().Split();            
            string beerName = nameBeerInput[0];
            int liters = int.Parse(nameBeerInput[1]);

            string[] numbersInput = Console.ReadLine().Split();
            int integer = int.Parse(numbersInput[0]);
            double doubleNumber = double.Parse(numbersInput[1]);


            Tuple<string, string> nameTown = new Tuple<string, string>(name, town );
            Tuple<string, int> nameBeer = new Tuple<string, int>(beerName, liters);

            Tuple<int, double> numbers = new Tuple<int, double>(integer, doubleNumber);

            Console.WriteLine(nameTown.GetItems());
            Console.WriteLine(nameBeer.GetItems());
            Console.WriteLine(numbers.GetItems());

        }
    }
}
