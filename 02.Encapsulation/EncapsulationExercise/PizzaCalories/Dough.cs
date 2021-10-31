using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string InvalidDoughExeptionMessage = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                string valueAsLower = value.ToLower();
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "white", "wholegrain"},
                    valueAsLower, InvalidDoughExeptionMessage);

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                string valueAsLower = value.ToLower();
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "homemade", "chewy", "crispy" },
                    valueAsLower, InvalidDoughExeptionMessage);

                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get { return this.weight; }
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double bakingTechniqueModifier = GetBakingTechniqueModifier();

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            string bakingTechniqueAsLower = this.BakingTechnique.ToLower();

            if (bakingTechniqueAsLower == "crispy")
            {
                return 0.9;
            }

            if (bakingTechniqueAsLower == "chewy")
            {
                return 1.1;
            }

            return 1;
        }

        private double GetFlourTypeModifier()
        {
            string flourTypeAsLower = this.FlourType.ToLower();
            
            if (flourTypeAsLower == "white")
            {
                return 1.5;
            }

            return 1;
        }
    }
}
