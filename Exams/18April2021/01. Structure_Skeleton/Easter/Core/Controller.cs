using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.IDyes;
using Easter.Models.IDyes.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnyes;
        private EggRepository eggs;
        private Workshop workshop;
        private int coloredEggs;
        public Controller()
        {
            bunnyes = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
            bunnyes.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnyes.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> validBunnys = bunnyes.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy).ToList();

            if (validBunnys.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            IEgg eggToWorkOn = eggs.FindByName(eggName);

            foreach (var bunny in validBunnys)
            {
                eggToWorkOn.GetColored();
                bunny.Work();

                if (bunny.Energy == 0)
                {
                    bunnyes.Remove(bunny);
                }

                workshop.Color(eggToWorkOn, bunny);
            }

            string progress = string.Empty;
             
            if (eggToWorkOn.IsDone())
            {
                progress = "done";
                coloredEggs++;
            }
            else
            {
                progress = "not done";
            }

            return $"Egg {eggName} is {progress}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnyes)
            {

            }
        }
    }
}
