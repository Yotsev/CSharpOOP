using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine()
                .Split(new char[] { ';','='}, StringSplitOptions.RemoveEmptyEntries);
            string[] productInfo = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < peopleInfo.Length-1; i+=2)
            {
                string name = peopleInfo[i];
                decimal money = decimal.Parse(peopleInfo[i + 1]);
                
                try
                {
                    people.Add(new Person(name, money));
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            for (int i = 0; i < productInfo.Length-1; i+=2)
            {
                string name = productInfo[i];
                decimal cost = decimal.Parse(productInfo[i+1]);

                products.Add(new Product(name,cost));
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string person = commandArgs[0];
                string product = commandArgs[1];

                Person existingPerson = GetPerson(people, person);
                Product existingProduct = GetProduct(products, product);

                existingPerson.AddToBag(existingProduct);

                command = Console.ReadLine();
            }

            foreach (var item in people)
            {
                if (item.BagOfProducts.Count==0)
                {
                    Console.WriteLine($"{item.Name} - Nothing bought ");
                }
                else
                {
                    Console.WriteLine($"{item.Name} - {string.Join(", ",item.BagOfProducts)}");
                }
            }
        }

        private static Product GetProduct(List<Product> products, string product)
        {
            foreach (var item in products)
            {
                if (item.Name == product)
                {
                    return item;
                }
            }

            return null;
        }

        private static Person GetPerson(List<Person> people,string person)
        {
            foreach (var item in people)
            {
                if (item.Name == person)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
