using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] currentCar = Console.ReadLine().Split();
                string model = currentCar[0];
                double fuelAmount = double.Parse(currentCar[1]);
                double fuelConsumption = double.Parse(currentCar[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumption, 0);
                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string carModel = commandArgs[1];
                double amountOfKm = double.Parse(commandArgs[2]);

                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Model == carModel)
                    {
                        
                        cars[i].Drive(amountOfKm);

                        if (cars[i].FuelAmount < 0)
                        {
                            cars[i].FuelAmount = 0;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
