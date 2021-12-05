using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"Race cannot be completed because both racers are not available!";
            }

            racerOne.Race();
            racerTwo.Race();

            double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                racerOneChance *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racerOneChance *= 1.1;
            }

            double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                racerTwoChance *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racerTwoChance *= 1.1;
            }

            IRacer winner;
            if (racerOneChance > racerTwoChance)
            {
                winner = racerOne;
            }
            else
            {
                winner= racerTwo;
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
        }
    }
}
