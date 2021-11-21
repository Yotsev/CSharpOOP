using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const double WeightGain = 1.00;
        public Tiger(string name, double weight, string livingRegion, string bread) 
            : base(name, weight, livingRegion, bread)
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
            return "ROAR!!!";
        }
    }
}
