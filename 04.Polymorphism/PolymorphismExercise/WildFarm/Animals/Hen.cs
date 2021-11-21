using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double WeightGain = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * WeightGain;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
