using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string listName, decimal salary) 
            : base(id, firstName, listName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            string baseInfo =  base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine("Privates:");

            foreach (var item in this.Privates)
            {
                sb.AppendLine($"  {item}");
            }


            return sb.ToString().Trim();
        }
    }
}
