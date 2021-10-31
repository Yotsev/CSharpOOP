using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            Team team = new Team("SoftUni");

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] personInfo = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Person currentPerson = new Person(personInfo[0], personInfo[1], int.Parse(personInfo[2]), decimal.Parse(personInfo[3]));

                    people.Add(currentPerson);

                }
                catch (ArgumentException ax)
                {
                    Console.WriteLine(ax.Message);
                }
            }

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team.FirstTeam.Count);
            Console.WriteLine(team.ReserveTeam.Count);
        }
    }
}


