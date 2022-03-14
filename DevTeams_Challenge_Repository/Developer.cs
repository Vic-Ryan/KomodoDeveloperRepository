using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum SkillSet { FrontEnd, BackEnd, Testing }
    public class Developer
    {
        public Developer() { }
        public Developer(int id)
        {
            DevID = id;
        }
        public Developer(int id, string firstName, string lastName) : this(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Developer(int id, string firstName, string lastName, bool pluralAccess) : this(id, firstName, lastName)
        {
            PluralsightAccess = pluralAccess;
        }
        public Developer(int id, string firstName, string lastName, bool pluralAccess, SkillSet teamAssignment) : this(id, firstName, lastName, pluralAccess)
        {
            SkillSet = teamAssignment;
        }
        public Developer(int id, string firstName, string lastName, bool pluralAccess, SkillSet teamAssignment, string email, string phoneNumber ) : this(id, firstName, lastName, pluralAccess, teamAssignment)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        //This is our POCO class. It will define our properties and constructors of our Developer objects.
        //Developer objects should have the following properties
        //ID (int)
        //FirstName
        //LastName
        //a bool that shows whether they have access to the online learning tool Pluralsight.
        //TeamAssignment - use the enum declared above this class
        public int DevID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } //Made into a String to catch errors. Not the best for memory, but at this stage, it's the best I can do to be user friendly.
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public bool PluralsightAccess { get; set; }
        public SkillSet SkillSet { get; set; }
        public bool HasAccessToPluralsight
        {
            get
            {
                if (PluralsightAccess)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
