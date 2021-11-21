using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        private const double WeightGain = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * WeightGain;
            }
            else
            {
                ThrowInvalidOperationExeptionForFood(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
