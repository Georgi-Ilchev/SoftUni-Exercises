using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitted = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = splitted[0];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(splitted[1]));
                            break;
                        case "Add":
                            if (!teams.Any(t => t.Name == splitted[1]))
                            {
                                throw new ArgumentException($"Team {splitted[1]} does not exist.");
                            }
                            else
                            {
                                Team currentTeam = teams.First(t => t.Name == splitted[1]);
                                currentTeam.AddPlayer(new Player(splitted[2], int.Parse(splitted[3]), int.Parse(splitted[4]), int.Parse(splitted[5]), int.Parse(splitted[6]), int.Parse(splitted[7])));
                            }
                            break;
                        case "Remove":
                            Team teamToRemove = teams.First(t => t.Name == splitted[1]);
                            teamToRemove.RemovePlayer(splitted[2]);
                            break;
                        case "Rating":
                            if (!teams.Any(t => t.Name == splitted[1]))
                            {
                                throw new ArgumentException($"Team {splitted[1]} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine(teams.First(t => t.Name == splitted[1]).ToString());
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
