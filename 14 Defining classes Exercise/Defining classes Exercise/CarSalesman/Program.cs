using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int nEngine = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < nEngine; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                string power = engineInfo[1];

                if (engineInfo.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }

                else if (engineInfo.Length == 3)
                {
                    if (char.IsDigit(engineInfo[2][0]))
                    {
                        engines.Add(new Engine(model, power, engineInfo[2]));
                    }
                   else
                    {
                        engines.Add(new Engine(model, power, "n/a", engineInfo[2]));
                    }

                }
                else if (engineInfo.Length == 4)
                {
                    engines.Add(new Engine(model, power, engineInfo[2], engineInfo[3]));
                }
            }

            int nCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < nCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                Engine engineModel = engines.FirstOrDefault(x => x.Model == carInfo[1]);

                if (carInfo.Length == 2)
                {
                    cars.Add(new Car(model, engineModel));
                }

                if (carInfo.Length == 3)
                {
                    if (char.IsDigit(carInfo[2][0]))
                    {
                        cars.Add(new Car(model, engineModel, carInfo[2]));
                    }
                    else
                    {
                        cars.Add(new Car(model, engineModel, "n/a", carInfo[2]));
                    }                   
                }
                else if (carInfo.Length == 4)
                {
                    cars.Add(new Car(model, engineModel, carInfo[2], carInfo[3]));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");

                foreach (var engine in engines.Where(x => x.Model == car.Engine.Model))
                {
                    Console.WriteLine($"    Power: {engine.Power}");
                    Console.WriteLine($"    Displacement: {engine.Displacement}");
                    Console.WriteLine($"    Efficiency: {engine.Efficiency}");
                }

                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
