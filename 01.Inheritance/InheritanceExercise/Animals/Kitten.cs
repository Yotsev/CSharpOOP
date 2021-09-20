using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string kitternGender = "female";
        public Kitten(string name, int age)
            : base(name, age, kitternGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
