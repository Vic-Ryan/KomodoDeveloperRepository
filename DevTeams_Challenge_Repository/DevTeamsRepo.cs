using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo : DevRepo
    {
        private readonly List<DevTeam> _devTeamDirectory = new List<DevTeam>();

        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        // C
        public bool AddNewDevTeam(DevTeam devTeam)
        {
            int startingCount = _devTeamDirectory.Count();
            _devTeamDirectory.Add(devTeam);
            bool wasAdded = (_devTeamDirectory.Count() > startingCount);
            return wasAdded;
        }


        public bool AddDeveloperToTeamByID(int devId, int teamId)
        {
            Developer developer = GetDevByID(devId);
            DevTeam dTeam = GetDevTeamById(teamId);
            dTeam.Developers.Add(developer);
            return dTeam.Developers.Count > 0 ? true : false;

        }
        // R
        public List<DevTeam> GetAllTeams()
        {
            return _devTeamDirectory;
        }
        public DevTeam GetDevTeamById(int teamId)
        {
            return _devTeamDirectory.Where(d => d.TeamID == teamId).SingleOrDefault();
        }

        public DevTeam GetDevTeamByName(string teamName)
        {
            return _devTeamDirectory.Where(d => d.TeamName == teamName).SingleOrDefault();
        }

        //public DevTeam DisplayDevTeamMembers()
        ///{
        // List<Developer> allDevelopers = new List<Developer>();
        // foreach (Developer developer in _developers)
        // {
        //     if
        // }
        // }
        //}
        // U


       /*
        public bool RemoveDeveloperFromTeamById(int devId, int teamId)
        {
            DevTeam dTeam = GetDevTeamById(teamId);
            Developer dev = dTeam.Developers.Where(d => d.DevID == devId).SingleOrDefault();
            if (dev != default)
            {
                return dTeam.Developers.Remove(dev);
            }
            else
                return false;
        }
        */ 
        public bool RemoveDeveloperToTeamByID(int devId, int teamId)
        {
            Developer developer = GetDevByID(devId);
            DevTeam dTeam = GetDevTeamById(teamId);
            dTeam.Developers.Remove(developer);
            return dTeam.Developers.Count >= 0 ? true : false;

        }
        public bool UpdateExistingTeamInfo(int originalId, DevTeam newInfo)
        {
            DevTeam oldTeamInfo = GetDevTeamById(originalId);
            if (oldTeamInfo != null)
            {
                oldTeamInfo.TeamID = newInfo.TeamID;
                oldTeamInfo.TeamName = newInfo.TeamName;
                return true;
            }
            else
                return false;
        }
        // D
        public bool DeleteExistingDevTeam(DevTeam existingTeam)
        {
            bool deleteResult = _devTeamDirectory.Remove(existingTeam);
            return deleteResult;
        }
    }
}
