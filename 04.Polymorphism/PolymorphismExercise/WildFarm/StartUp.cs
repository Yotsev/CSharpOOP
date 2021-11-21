using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IAnimal> animals = new List<IAnimal>();

            while (input != "End")
            {
                try
                {
                    string[] inputInfo = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string type = inputInfo[0];
                    string name = inputInfo[1];
                    double weight = double.Parse(inputInfo[2]);

                    string[] foodInfo = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string foodType = foodInfo[0];
                    int qty = int.Parse(foodInfo[1]);

                    IAnimal animal = null;

                    if (type == "Cat" || type == "Tiger")
                    {
                        string livingRegion = inputInfo[3];
                        string bred = inputInfo[4];

                        if (type == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, bred);
                        }
                        else if (type == "Tiger")
                        {
                            animal = new Tiger(name, weight, livingRegion, bred);
                        }

                    }
                    else if (type == "Owl" || type == "Hen")
                    {
                        double wingSize = double.Parse(inputInfo[3]);

                        if (type == "Owl")
                        {
                            animal = new Owl(name, weight, wingSize);
                        }
                        else if (type == "Hen")
                        {
                            animal = new Hen(name, weight, wingSize);
                        }
                    }
                    else if (type == "Mouse" || type == "Dog")
                    {
                        string livingRegion = inputInfo[3];

                        if (type == "Mouse")
                        {
                            animal = new Mouse(name, weight, livingRegion);
                        }
                        else if (type == "Dog")
                        {
                            animal = new Dog(name, weight, livingRegion);
                        }
                    }

                    Console.WriteLine(animal.ProduceSound());

                    animals.Add(animal);

                    IFood food = null;

                    if (foodType == "Fruit")
                    {
                        food = new Fruit(qty);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(qty);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(qty);
                    }
                    else if (foodType == "Vegetable")
                    {
                        food = new Vegetable(qty);
                    }

                    animal.Eat(food);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
 
 

