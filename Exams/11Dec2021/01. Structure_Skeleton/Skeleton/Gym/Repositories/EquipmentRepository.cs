using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipment;

        public EquipmentRepository()
        {
            this.equipment = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models { get { return this.equipment; } }

        public void Add(IEquipment model)
        {
            this.equipment.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.Models.FirstOrDefault(e => e.GetType().Name.Equals(type));
        }

        public bool Remove(IEquipment model)
        {
            return this.equipment.Remove(model);
        }
    }
}
