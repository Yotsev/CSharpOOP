using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();  
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get { return bagOfProducts.AsReadOnly(); }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public void AddToBag(Product product)
        {
            if (!CanAfford(product))
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                bagOfProducts.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
        }

        private bool CanAfford(Product product)
        {
            bool canAfford = money >= product.Cost;

            return canAfford;
        }
    }
}
