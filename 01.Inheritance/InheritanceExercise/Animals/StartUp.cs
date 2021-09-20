using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                if (string.IsNullOrEmpty(name) || age <0|| string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                if (command == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (command == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (command == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);

                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (command == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);

                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
                else if (command == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);

                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }

                command = Console.ReadLine();
            }
        }
    }
}
