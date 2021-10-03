using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Filter_by_Age
{
    class Person
    {
        public string Name;

        public int Age;

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] lineArgs = line.Split(", ");
                string name = lineArgs[0];
                int age = int.Parse(lineArgs[1]);

                Person person = new Person();
                person.Name = name;
                person.Age = age;

                people.Add(person);
            }

            var filterName = Console.ReadLine();
            var ageToCompare = int.Parse(Console.ReadLine());
            

            Func<Person, bool> filter = p => true;
            if (filterName == "younger")
            {
                filter = p => p.Age < ageToCompare;
            }
            else if (filterName == "older")
            {
                filter = p => p.Age >= ageToCompare;
            }

            var filterdPeople = people.Where(filter);

            var printName = Console.ReadLine();

            Func<Person, string> printFunc = p => p.Name + " - " + p.Age;
            
            if (printName == "name age")
            {
                printFunc = p => p.Name + " - " + p.Age;
            }
            else if(printName == "name")
            {
                printFunc = p => p.Name;
            }
            else if (printName == "age")
            {
                printFunc = p => p.Age.ToString();
            }

            var results = filterdPeople.Select(printFunc);
            foreach (var str in results)
            {
                Console.WriteLine(str);
            }

        }
    }
}
