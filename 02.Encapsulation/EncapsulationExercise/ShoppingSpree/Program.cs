using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine()
                .Split(";");

            string[] productsInfo = Console.ReadLine()
                .Split(";");

            Dictionary<string, Person> people = new Dictionary<string, Person>();

            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string[] currentPerson = peopleInfo[i]
                    .Split("=");
                try
                {
                    string name = currentPerson[0];
                    decimal money = decimal.Parse(currentPerson[1]);

                    Person current = new Person(name, money);

                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, current);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            Dictionary<string, Product> products = new Dictionary<string, Product>();

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] currentProduct = productsInfo[i]
                    .Split("=");
                try
                {
                    string name = currentProduct[0];
                    decimal cost = decimal.Parse(currentProduct[1]);

                    if (!products.ContainsKey(name))
                    {
                        products.Add(name, new Product(name, cost));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = commandArgs[0];
                string productName = commandArgs[1];

                if (people[personName].Money < products[productName].Cost)
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} bought {productName}");

                    people[personName].Products.Add(products[productName]);
                    people[personName].Money -= products[productName].Cost;
                }

                command = Console.ReadLine();
            }

            foreach (Person person in people.Values)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => x.Name))}");
                }
            }
        }
    }
}
