using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class SportCar:Car
    {
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 10;
        }

        public override void Drive(double kilometers)
        {
            Fuel -= DefaultFuelConsumption  * kilometers;
        }
    }
}
