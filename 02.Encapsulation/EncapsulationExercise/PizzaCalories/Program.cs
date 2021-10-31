using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split(" ")[1];
            string[] doughInfo = Console.ReadLine().Split(" ");

            try
            {
                Dough dough = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingInfo = command.Split(" ");

                    Topping currentToping = new Topping(toppingInfo[1], int.Parse(toppingInfo[2]));
                    pizza.AddTopping(currentToping);

                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
            }
            catch (Exception ex)
                when (ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
