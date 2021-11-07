using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
   public interface ISmartphone: IStationary
    {
        public string Browsing(string website);
    }
}
