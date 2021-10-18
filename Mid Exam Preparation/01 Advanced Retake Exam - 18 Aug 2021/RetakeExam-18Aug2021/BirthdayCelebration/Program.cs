using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guestNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> guestValue = new Queue<int>(guestNumber);

            int[] plateNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> plates = new Stack<int>(plateNumber);

            int wastedFood = 0;

            while (guestValue.Count > 0 && plates.Count > 0)
            {
                int currentGuest = guestValue.Peek();
                int currentPlate = plates.Peek();

                if (currentGuest < currentPlate)
                {
                    wastedFood += currentPlate - currentGuest;
                    guestValue.Dequeue();
                    plates.Pop();
                }
                else if (currentGuest == currentPlate)
                {
                    guestValue.Dequeue();
                    plates.Pop();
                }
                else if (currentGuest > currentPlate)
                {
                    while (currentGuest > 0 && plates.Count > 0)
                    {
                        currentGuest = currentGuest - currentPlate;
                        plates.Pop();
                        if (plates.Count > 0)
                        {
                            currentPlate = plates.Peek();

                            if (currentGuest < currentPlate)
                            {
                                wastedFood += currentPlate - currentGuest;
                                currentGuest = 0;
                                guestValue.Dequeue();
                                plates.Pop();
                            }
                            else if (currentGuest == currentPlate)
                            {
                                currentGuest = 0;
                                guestValue.Dequeue();
                                plates.Pop();
                            }
                        }
                    }

                }
            }

            if (guestValue.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
            else if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestValue)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
        }
    }
}
