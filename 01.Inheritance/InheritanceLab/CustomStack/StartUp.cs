using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings elements = new StackOfStrings();

            Stack<string> newElements = new Stack<string>();

            newElements.Push("something");
            newElements.Push("Anything");

            Console.WriteLine(elements.IsEmpty());

            elements.AddRange(newElements);
            Console.WriteLine(elements.IsEmpty());
        }
    }
}
