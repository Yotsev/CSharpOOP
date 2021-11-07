using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] buyerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (buyerInfo.Length == 3)
                {
                    Rebel rebel = new Rebel(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2]);
                    buyers.Add(buyerInfo[0], rebel);
                }
                else
                {
                    Citizen citizen = new Citizen(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2], buyerInfo[3]);
                    buyers.Add(buyerInfo[0], citizen);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (buyers.ContainsKey(command))
                {
                    buyers[command].BuyFood();
                }

                command = Console.ReadLine();
            }

            int totalFood = buyers.Values.Sum(x => x.Food);

            Console.WriteLine(totalFood);
        }
    }
}
