using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfNumberIsNotInRange(int min, int max, int number, string message)
        {
            if (number<min || number>max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfValueIsNotAllowed(HashSet<string> allowedValues, string value, string message)
        {
            if (!allowedValues.Contains(value))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
