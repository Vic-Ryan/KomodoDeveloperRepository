using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeam
    {
        public DevTeam () { }
        public DevTeam (int teamID, string teamName)
        {
            TeamID = teamID;
            TeamName = teamName;
        }
        public DevTeam(int teamID, string teamName, List<Developer> developers) : this(teamID, teamName)
        {
            Developers = developers;
        }

        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<Developer> Developers { get; set; } = new List<Developer>();
    }
}
