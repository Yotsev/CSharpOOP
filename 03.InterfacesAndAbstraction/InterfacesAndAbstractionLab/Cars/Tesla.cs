using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    partial class Tesla : ICar, IElectricCar
    {
        public string Model { get; }

        public string Color { get; }

        public int Battery  { get; }

        public Tesla(string mode, string color, int battery)
        {
            this.Model = mode;
            this.Color = color;
            this.Battery = battery;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} with {this.Battery} Batteries{Environment.NewLine}{this.Start()}{Environment.NewLine}{this.Stop()}";
        }
    }
}
