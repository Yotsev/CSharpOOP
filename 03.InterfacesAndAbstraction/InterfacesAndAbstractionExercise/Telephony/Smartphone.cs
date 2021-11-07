using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {

        public string Calling(string number)
        {
            return $"Calling... {number}";
        }

        public string Browsing(string website)
        {
            return $"Browsing: {website}!";
        }
    }
}
