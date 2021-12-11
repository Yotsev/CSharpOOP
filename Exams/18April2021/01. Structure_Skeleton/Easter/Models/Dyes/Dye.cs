using Easter.Models.IDyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.IDyes
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {

        }

        public int Power 
        { 
            get { return this.power; }
            set 
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                this.power = value; 
            }
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            if (this.Power <0)
            {
                this.Power = 0;
            }
        }
    }
}
