using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;
        public Egg(string name, int energyRequired)
        {

        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get { return this.energyRequired; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energyRequired = value;
            }
        }

        public void GetColored()
        {
            if (this.EnergyRequired -10<0)
            {
                this.EnergyRequired = 0;
            }
            else
            {
                this.EnergyRequired -= 10;
            }
        }

        public bool IsDone()
        {
            return this.EnergyRequired == 0;
        }
    }
}
