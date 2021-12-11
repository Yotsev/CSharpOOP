using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private readonly List<IEquipment> equpment;
        private readonly List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equpment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Capacity
        {
            get;
            private set;
        }

        public double EquipmentWeight
        {
            get
            {
                double result = 0;
                foreach (var item in Equipment)
                {
                    result += item.Weight;
                }
                return result;
            }
        }

        public ICollection<IEquipment> Equipment { get { return this.equpment; }}

        public ICollection<IAthlete> Athletes { get { return this.athletes; }}

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == Athletes.Count )
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            string athlatesInfo = string.Empty;
            if (this.Athletes.Count == 0)
            {
                athlatesInfo = "No athletes";
            }
            else
            {
                athlatesInfo = string.Join(", ",Athletes.Select(a=>a.FullName));
            }
            sb.AppendLine($"Athletes: {athlatesInfo}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }
    }
}
