using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string listName, decimal salary,Corps corps) 
            : base(id, firstName, listName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; private set; }
    }
}
