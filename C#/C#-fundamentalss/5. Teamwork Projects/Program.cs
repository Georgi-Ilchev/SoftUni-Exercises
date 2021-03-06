using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Team> allTeams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split("-");
                string creator = tokens[0];
                string name = tokens[1];

                Team existingTeam = allTeams.Find(t => t.Name == name);
                Team existingTeamCreator = allTeams.Find(t => t.Creator == creator);

                if (existingTeam != null)
                {
                    Console.WriteLine($"Team {name} was already created!");
                    continue;
                }

                if (existingTeamCreator != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team myTeam = new Team(tokens[0], tokens[1]);
                allTeams.Add(myTeam);
                Console.WriteLine($"Team {myTeam.Name} has been created by {myTeam.Creator}!");
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] tokens = input.Split("->");
                string member = tokens[0];
                string name = tokens[1];

                Team existingTeam = allTeams.Find(t => t.Name == name);
                Team existingTeamMember = allTeams.Find(t => t.Members.Contains(member) || t.Creator == member);

                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {name} does not exist!");
                    input = Console.ReadLine();
                    continue;
                }

                if (existingTeamMember != null)
                {
                    Console.WriteLine($"Member {member} cannot join team {name}!");
                    input = Console.ReadLine();
                    continue;
                }

                existingTeam.Members.Add(member);
                input = Console.ReadLine();
            }

            List<string> allDisbandedTeams = allTeams
                .Where(a => a.Members.Count == 0)
                .OrderBy(a => a.Name)
                .Select(a => a.Name)
                .ToList();

            allTeams.RemoveAll(t => t.Members.Count == 0);
            List<Team> sortedTeams = allTeams
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();

            foreach (Team t in sortedTeams)
            {
                Console.WriteLine(t.ToString());
            }

            Console.WriteLine($"Teams to disband:");

            foreach (string t in allDisbandedTeams)
            {
                Console.WriteLine(t);
            }
        }
    }

    class Team
    {
        public Team(string creator, string name)
        {
            this.Creator = creator;
            this.Name = name;
            this.Members = new List<string>();
        }
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            List<string> sortedMembers = this.Members
                .OrderBy(a => a)
                .ToList();

            string output = $"{this.Name}\n";
            output += $"- {this.Creator}\n";

            for (int i = 0; i < sortedMembers.Count; i++)
            {
                output += $"-- {sortedMembers[i]}\n";
            }
            return output.Trim();
        }
    }
}
