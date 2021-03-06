using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr._07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }
        public List<Mission> Missions
        {
            get => this.missions;
            private set
            {
                this.missions = value;
                CompleteMission(this.missions);
            }
        }

        public void CompleteMission(List<Mission> missions)
        {
            Mission invalidMission = missions.FirstOrDefault(m => m.State != "inProgress" && m.State != "Finished");

            while (invalidMission != null)
            {
                this.missions.Remove(invalidMission);
                invalidMission = missions.FirstOrDefault(m => m.State != "inProgress" && m.State != "Finished");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
