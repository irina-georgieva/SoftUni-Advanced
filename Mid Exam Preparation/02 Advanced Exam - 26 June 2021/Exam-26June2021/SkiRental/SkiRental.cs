using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> ski;
        private string name;
        private int capacity;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            ski = new List<Ski>();
        }

        public int Count => ski.Count;

        public void Add(Ski data)
        {
            if (ski.Count + 1<= Capacity)
            {
                ski.Add(data);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = ski.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            
            if (skiToRemove == null)
            {
                return false;
            }
            ski.Remove(skiToRemove);
            return true;
        }

        public Ski GetNewestSki()
        {
            if (ski.Count > 0)
            {
                return ski.OrderByDescending(s => s.Year).FirstOrDefault();
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski skiToGet = ski.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            if (skiToGet == null)
            {
                return null;
            }

            return skiToGet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in ski)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
