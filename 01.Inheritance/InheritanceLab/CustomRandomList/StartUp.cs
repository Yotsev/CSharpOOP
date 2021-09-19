using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList()
            {
                "Pesho",
                "Gosho",
                "Ivan"
            };

            rndList.RandomString();
        }
    }
}
