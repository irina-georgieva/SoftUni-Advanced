using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
        }

        private static void OpinionPoll()
        {
            int n = int.Parse(Console.ReadLine());
            Family people = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().Split();
                if (int.Parse(currentPerson[1]) > 30)
                {
                    Person person = new Person(currentPerson[0], int.Parse(currentPerson[1]));
                    people.AddMember(person);
                }
                else
                {
                    continue;
                }
            }

            foreach (var person in people.People.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

        private static void GetOldestMember()
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
