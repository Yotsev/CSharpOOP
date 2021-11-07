using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();


            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].All(char.IsDigit))
                {
                    if (numbers[i].Length == 10)
                    {
                        Console.WriteLine(smartphone.Calling(numbers[i]));
                    }
                    else if (numbers[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Calling(numbers[i]));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < websites.Length; i++)
            {
                if (websites[i].Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(smartphone.Browsing(websites[i]));
                }
            }
        }
    }
}
