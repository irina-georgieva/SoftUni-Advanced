using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Tire[]> newTires = new List<Tire[]>();

            while (command != "No more tires")
            {
                List<string> tireSet = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                Tire[] currentTireSet = new Tire[4];
                for (int i = 0; i < 4; i++)
                {
                    Tire currentTire = new Tire(int.Parse(tireSet[0]), double.Parse(tireSet[1]));
                    currentTireSet[i] = currentTire;
                    tireSet.RemoveAt(0);
                    tireSet.RemoveAt(0);
                }
                newTires.Add(currentTireSet);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            List<Engine> newEngines = new List<Engine>();

            while (command != "Engines done")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(commandArgs[0]);
                double cubics = double.Parse(commandArgs[1]);

                Engine newEngine = new Engine(horsePower, cubics);
                newEngines.Add(newEngine);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            List<Car> newCars = new List<Car>();

            while (command != "Show special")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = commandArgs[0];
                string model = commandArgs[1];
                int year = int.Parse(commandArgs[2]);
                double fuelQuantity = double.Parse(commandArgs[3]);
                double fuelConsumption = double.Parse(commandArgs[4]);
                Engine engineIndex = newEngines[int.Parse(commandArgs[5])];
                Tire[] tireIndex = newTires[int.Parse(commandArgs[6])];

                Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engineIndex, tireIndex);
                newCars.Add(newCar);

                command = Console.ReadLine();
            }

            foreach (var car in newCars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330
            && x.Tires.Sum(p => p.Pressure) > 9 
            && x.Tires.Sum(p => p.Pressure) <= 10))
            {
                car.FuelQuantity -= 20 * (car.FuelConsumption /100);
                
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}" +
                    $"\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
