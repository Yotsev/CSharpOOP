using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.IDyes.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone())
            {
                if (bunny.Energy != 0 || bunny.Dyes.Count>0)
                {
                    IDye dye = bunny.Dyes.FirstOrDefault();
                    egg.GetColored();
                    dye.Use();
                    bunny.Work();

                    if (dye.IsFinished())
                    {
                        bunny.Dyes.Remove(dye);
                    }
                }
            }
        }
    }
}
