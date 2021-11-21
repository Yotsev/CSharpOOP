using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        private const double WeightGain = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                ThrowInvalidOperationExeptionForFood(this, food);
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * WeightGain;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
