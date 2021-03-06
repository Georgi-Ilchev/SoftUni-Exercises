using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._07.MilitaryElite
{
    public interface ICommando
    {
        List<Mission> Missions { get; }
        public void CompleteMission(List<Mission> missions);
    }
}
