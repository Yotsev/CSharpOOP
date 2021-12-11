using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName,motivation,numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            if (gym.GetType().Name == "BoxingGym" && athlete.GetType().Name == "Boxer")
            {
                gym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else if (gym.GetType().Name == "WeightliftingGym" && athlete.GetType().Name == "Weightlifter")
            {
                gym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else
            {
                return $"The gym is not appropriate.";
            }
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currentEquipment;
            if (equipmentType == "BoxingGloves")
            {
                currentEquipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                currentEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidCastException("Invalid equipment type.");
            }

            equipment.Add(currentEquipment);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            
            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            double weight = gym.EquipmentWeight;
            return $"The total weight of the equipment in the gym {gymName} is {weight:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipmentToAdd = equipment.FindByType(equipmentType);
            if (equipmentToAdd == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            var targetGym = gyms.FirstOrDefault(g=> g.Name == gymName);
            targetGym.AddEquipment(equipmentToAdd);
            equipment.Remove(equipmentToAdd);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in gyms)
            {
                sb.AppendLine(item.GymInfo().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
          IGym gym = gyms.FirstOrDefault(g=>g.Name == gymName);
            int count = 0;
            foreach (var item in gym.Athletes)
            {
                item.Exercise();
                count++;
            }

            return $"Exercise athletes: {count}.";
        }
    }
}
