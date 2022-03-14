using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevRepo 
    {
        protected readonly List<Developer> _devDirectory = new List<Developer>();
        //Create
        public bool AddDeveloper(Developer developer)
        {
            int startingCount = _devDirectory.Count();
            _devDirectory.Add(developer);
            bool wasAdded = (_devDirectory.Count() > startingCount);
            return wasAdded;
        }
        //Read

        public List<Developer> GetAllDevelopers()
        {
            return _devDirectory;
        }

        public Developer GetDevByID(int id)
        {
            return _devDirectory.Where(d => d.DevID == id).SingleOrDefault();
        }

        public List<Developer> GetUnlicensedDevelopers()
        {
            List<Developer> notPluralLicensed = new List<Developer>();
            foreach (Developer developer in _devDirectory)
            {
                if (!developer.HasAccessToPluralsight)
                {
                    notPluralLicensed.Add(developer);
                }
            }
            return notPluralLicensed;
        }

        public List<Developer> GetSkillType(SkillSet assignment)
        {
            return _devDirectory.Where(d => d.SkillSet == assignment).ToList();
        }

        //Update
        public bool UpdateExistingDevInfo(int originalID, Developer newInfo)
        {
            Developer oldInfo = GetDevByID(originalID);
            if (oldInfo != null)
            {
                oldInfo.DevID = newInfo.DevID;
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.Email = newInfo.Email;
                oldInfo.PhoneNumber = newInfo.PhoneNumber;
                oldInfo.PluralsightAccess = newInfo.PluralsightAccess;
                oldInfo.SkillSet = newInfo.SkillSet;

                return true;
            }
            else
                return false;
        }
        //Delete
        public bool DeleteExistingDevInfo(Developer existingInfo)
        {
            bool deleteResult = _devDirectory.Remove(existingInfo);
            return deleteResult;
        }
    }
}
