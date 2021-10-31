﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
   public class Kitten : Cat
    {
        private const string KitternGender = "female";
        public Kitten(string name, int age)
            : base(name, age, KitternGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
