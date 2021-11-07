using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IStationary
    {
        public string Calling(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
