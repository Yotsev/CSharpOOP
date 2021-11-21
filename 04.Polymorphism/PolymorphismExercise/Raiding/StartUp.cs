using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfRaiders = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count < numberOfRaiders)
            {
                string name = Console.ReadLine();
                string @class = Console.ReadLine();

                BaseHero hero = null;
                if (@class != "Druid" && @class != "Paladin" && @class != "Rogue" && @class != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                }
                else if (@class == "Druid")
                {
                    hero = new Druid(name);
                    heroes.Add(hero);
                }
                else if (@class == "Paladin")
                {
                    hero = new Paladin(name);
                    heroes.Add(hero);
                }
                else if (@class == "Rogue")
                {
                    hero = new Rogue(name);
                    heroes.Add(hero);
                }
                else if (@class == "Warrior")
                {
                    hero = new Warrior(name);
                    heroes.Add(hero);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int sum = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                sum += hero.Power;
            }

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
