using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Pr._07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();
            List<Private> privates = new List<Private>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = splitted[0];
                string id = splitted[1];
                string firstName = splitted[2];
                string lastName = splitted[3];
                decimal salary = decimal.Parse(splitted[4]);

                string corps;

                switch (type)
                {
                    case "Private":
                        Private privateSoldier = new Private(id, firstName, lastName, salary);
                        privates.Add(privateSoldier);
                        soldiers.Add(privateSoldier);
                        break;
                    case "LieutenantGeneral":
                        List<Private> privatesOfLieutenantGeneral = GetPrivatesOfLieutenantGeneral(privates, splitted);
                        soldiers.Add(new LieutenantGeneral(id, firstName, lastName, salary, privatesOfLieutenantGeneral));
                        break;
                    case "Engineer":
                        corps = splitted[5];
                        List<Repair> repairs = GetPairs(splitted);
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        if (engineer.Corps == null)
                        {
                            continue;
                        }
                        soldiers.Add(engineer);
                        break;
                    case "Commando":
                        corps = splitted[5];
                        List<Mission> missions = GetMissions(splitted);
                        Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                        if (commando.Corps == null)
                        {
                            continue;
                        }
                        soldiers.Add(commando);
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(splitted[4]);
                        soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                        break;
                    default:
                        break;
                }
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
        private static List<Private> GetPrivatesOfLieutenantGeneral(List<Private> privates, string[] info)
        {
            List<Private> privatesOfLieutenantGeneral = new List<Private>();
            for (int i = 4; i < info.Length; i++)
            {
                string privateId = info[i];
                if (privates.Any(x => x.Id == privateId))
                {
                    privatesOfLieutenantGeneral.Add(privates.First(x => x.Id == privateId));
                }
            }
            return privatesOfLieutenantGeneral;
        }

        private static List<Repair> GetPairs(string[] info)
        {
            List<Repair> repairs = new List<Repair>();
            for (int i = 6; i < info.Length; i += 2)
            {
                string repairPart = info[i];
                int repairHours = int.Parse(info[i + 1]);
                repairs.Add(new Repair(repairPart, repairHours));
            }
            return repairs;
        }
        private static List<Mission> GetMissions(string[] info)
        {
            List<Mission> missions = new List<Mission>();
            for (int i = 6; i < info.Length - 1; i += 2)
            {
                string missionCodeName = info[i];
                string missionState = info[i + 1];
                missions.Add(new Mission(missionCodeName, missionState));
            }
            return missions;
        }
    }
}
