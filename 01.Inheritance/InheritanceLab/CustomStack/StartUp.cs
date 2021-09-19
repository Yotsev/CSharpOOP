using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings elements = new StackOfStrings();

            List<string> newElements = new List<string>()
            {
                "Something",
                "Anything",
                "Something else"
            };

            Console.WriteLine(elements.IsEmpty());

            elements.AddRange(newElements);
            Console.WriteLine(elements.IsEmpty());

            Console.WriteLine(string.Join(", ",elements));
        }
    }
}
