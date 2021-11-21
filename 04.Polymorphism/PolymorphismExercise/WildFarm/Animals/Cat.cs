using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        private const double WeightGain = 0.30;
        public Cat(string name, double weight, string livingRegion, string bread) 
            : base(name, weight, livingRegion, bread)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat || food is Vegetable)
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
            return "Meow";
        }
    }
}
