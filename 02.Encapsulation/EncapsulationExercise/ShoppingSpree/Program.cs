using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string[] currentPersonInfo = peopleInfo[i].Split("=");
                try
                {
                    Person currentPerson = new Person(currentPersonInfo[0], decimal.Parse(currentPersonInfo[1]));
                    people.Add(currentPerson);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
            }

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] currentProductInfo = productsInfo[i].Split("=");
                try
                {
                    Product currentProduct = new Product(currentProductInfo[0], decimal.Parse(currentProductInfo[1]));
                    products.Add(currentProduct);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person currentPerson = people.FirstOrDefault(p => p.Name == commandArgs[0]);
                Product currrentProduct = products.FirstOrDefault(p => p.Name == commandArgs[1]);

                if (currrentProduct.Cost>currentPerson.Money)
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currrentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} bought {currrentProduct.Name}");
                    currentPerson.AddProduct(currrentProduct);
                }

                command = Console.ReadLine();
            }

            foreach (Person person in people)
            {
                if (person.Products.Count>0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join($", ",person.Products.Select(p => p.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                }
            }
        }
    }
}
