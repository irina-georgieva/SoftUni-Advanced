using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
            TravelledDistance = travelledDistance;
        }

        public Car(string carModel, double distance)
        {
            Model = carModel;
            TravelledDistance = distance;
        }

        public void Drive(double amountKm)
        {
            if (FuelAmount - (amountKm * FuelConsumptionPerKilometer) >= 0)
            {
                FuelAmount -= (amountKm * FuelConsumptionPerKilometer);
                TravelledDistance += amountKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
