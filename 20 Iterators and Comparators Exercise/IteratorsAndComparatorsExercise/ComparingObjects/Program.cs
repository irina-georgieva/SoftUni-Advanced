using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (command != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);
                string town = commandArgs[2];
                Person currentPerson = new Person(name, age, town);
                
                persons.Add(currentPerson);

                command = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;
            var notEqual = 0;

            foreach (var person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {persons.Count}");
            }
        }
    }
}
