using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private readonly DevTeamsRepo _devTeamRepo = new DevTeamsRepo();
        //private readonly DevRepo _devRepo = new DevRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            bool devMenu = true;
            while (continueToRun)
            {
                if (devMenu)
                {

                    Console.Clear();

                    Console.WriteLine("Komodoo Insurance Developer Database\n" +
                        "Please enter the number of the option you would like: \n" +
                        "1. Display all currently employed Developers\n" +
                        "2. Display Developer by ID\n" +
                        "3. Add new Developer profile\n" +
                        "4. Update existing Developer information\n" +
                        "5. Display Pluralsight License Status \n" +
                        "6. Delete existing Developer information\n" +
                        "7. Go to Development Team database \n" +
                        "8. Exit");

                    //Code below is typed out in order in program\
                    //Broken in half, team commands will be marked after developer commands
                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            DisplayAllDevelopers();
                            break;
                        case "2":
                            DisplayDeveloperByID();
                            break;
                        case "3":
                            AddDeveloper();
                            break;
                        case "4":
                            UpdateDeveloperInfo();
                            break;
                        case "5":
                            GetUnLicensedDevelopers();
                            break;
                        case "6":
                            DeleteDeveloperInfo();
                            break;
                        case "7":
                            devMenu = false;
                            break;
                        case "8":
                        case "e":
                        case "E":
                        case "exit":
                        case "Exit":
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please input a valid number between 1 and 8.\n" +
                                "Press any key to continue");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Komodo Insurance Development Team Database\n" +
                        "Please enter the number of the option you would like to choose:\n" +
                        "1. Display all teams\n" +
                        "2. Display team by ID \n" +
                        "3. Add new development team \n" +
                        "4. Add developer to team\n" +
                        "5. Remove developer from team\n" +
                        "6. Update development team information \n" +
                        "7. Delete existing development team \n" +
                        "8. Return to Developer Database \n" +
                        "9. Exit");

                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            DisplayAllDevTeams();
                            break;
                        case "2":
                            DisplayTeamByID();
                            break;
                        case "3":
                            AddDevTeam();
                            break;
                        case "4":
                            AddDeveloperToTeam();
                            break;
                        case "5":
                            RemoveDeveloperFromTeam();
                            break;
                        case "6":
                            UpdateDevTeam();
                            break;
                        case "7":
                            DeleteExistingDevTeam();
                            break;
                        case "8":
                            devMenu = true;
                            break;
                        case "9":
                        case "e":
                        case "E":
                        case "exit":
                        case "Exit":
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please input a valid number between 1 and 8.\n" +
                                "Press any key to continue");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }

        private void DisplayAllDevelopers()
        {
            Console.Clear();
            ListDevelopersByID();
            AnyKey();
        }

        private void DisplayDeveloperByID()
        {
            Console.Clear();
            ListDevelopersByID();
            Console.Write("Enter Developer ID: ");
            int devId = int.Parse(Console.ReadLine());
            Developer developer = _devTeamRepo.GetDevByID(devId);
            if (developer != null)
            {
                DisplayDevFullInfo(developer);
            }
            else
            {
                Console.WriteLine("Could not find developer connected to this ID.");
            }
            AnyKey();
        }

        private void AddDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Enter new developer information.");
            Developer developer = new Developer();
            Console.Write("Enter Developer ID: ");
            developer.DevID = int.Parse(Console.ReadLine());
            Console.Write("Enter First Name: ");
            developer.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            developer.LastName = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            developer.Email = Console.ReadLine();
            Console.Write("Enter Phone Number (XXX)XXX-XXXX: ");
            developer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Select Developer Specialty:\n" +
                "1. FrontEnd\n" +
                "2. BackEnd\n" +
                "3. Testing");
            string devSpecialty = Console.ReadLine();
            switch (devSpecialty)
            {
                case "1":
                    developer.SkillSet = SkillSet.FrontEnd;
                    break;
                case "2":
                    developer.SkillSet = SkillSet.BackEnd;
                    break;
                case "3":
                    developer.SkillSet = SkillSet.Testing;
                    break;
            }
            Console.Write("Do they have a Pluralsight License? Y/N: ");
            string pluralAccess = Console.ReadLine().ToLower();
            switch (pluralAccess)
            {
                case "true":
                case "y":
                case "yes":
                    developer.PluralsightAccess = true;
                    break;
                case "false":
                case "n":
                case "no":
                default:
                    developer.PluralsightAccess = false;
                    break;
            }
            if (_devTeamRepo.AddDeveloper(developer))
            {
                Console.WriteLine("Success, developer added succesfully.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failure, something went wrong.");
                Console.ReadKey();
            }
        }
        private void UpdateDeveloperInfo()
        {
            Console.Clear();
            Developer newDev = new Developer();
            ListDevelopersByID();
            Console.Write("Please enter the ID of the Developer you wish to update: ");
            Developer oldInfo = _devTeamRepo.GetDevByID(int.Parse(Console.ReadLine()));
            if (oldInfo != null)
            {
                Console.Clear();
                Console.WriteLine("Enter updated information, leave blank if unchanged");
                Console.Write("Enter Developer ID: ");
                string idInput = Console.ReadLine();
                if (idInput != "")
                {
                    oldInfo.DevID = int.Parse(idInput);
                }
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                if (firstName != "")
                {
                    oldInfo.FirstName = firstName;
                }
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();
                if (lastName != "")
                {
                    oldInfo.LastName = lastName;
                }
                Console.Write("Enter Email Address: ");
                string emailInput = Console.ReadLine();
                if (emailInput != "")
                {
                    oldInfo.Email = emailInput;
                }
                Console.Write("Enter Phone Number (XXX)XXX-XXXX: ");
                string phoneInput = Console.ReadLine();
                if (phoneInput != "")
                {
                    oldInfo.PhoneNumber = phoneInput;
                }
                Console.WriteLine("Select Developer Specialty:\n" +
                    "1. FrontEnd\n" +
                    "2. BackEnd\n" +
                    "3. Testing");
                string devSpecialty = Console.ReadLine();
                if (devSpecialty != "")
                {
                    switch (devSpecialty)
                    {
                        case "1":
                            oldInfo.SkillSet = SkillSet.FrontEnd;
                            break;
                        case "2":
                            oldInfo.SkillSet = SkillSet.BackEnd;
                            break;
                        case "3":
                            oldInfo.SkillSet = SkillSet.Testing;
                            break;

                    }
                }
                Console.Write("Do they have a Pluralsight License? Y/N: ");
                string psAccess = Console.ReadLine().ToLower();
                if (psAccess != "")
                {
                    switch (psAccess)
                    {
                        case "y":
                        case "yes":
                        case "true":
                        case "t":
                            oldInfo.PluralsightAccess = true;
                            break;
                        case "n":
                        case "no":
                        case "f":
                        case "false":
                            oldInfo.PluralsightAccess = false;
                            break;
                    }
                }
            }
            else
                Console.WriteLine("No Developer by that ID found.");
            AnyKey();
        }
        private void GetUnLicensedDevelopers()
        {
            Console.Clear();
            Console.WriteLine("Developers currently in need of Pluralsight Licenses:");
            List<Developer> listofDevelopers = _devTeamRepo.GetAllDevelopers();
            foreach (Developer developer in listofDevelopers)
            {
                if (developer.HasAccessToPluralsight == false)
                {
                    DisplayDevBasicInfo(developer);
                }
            }
            AnyKey();
        }
        private void DeleteDeveloperInfo()
        {
            Console.Clear();
            List<Developer> developerList = _devTeamRepo.GetAllDevelopers();
            int count = 0;
            foreach (Developer developer in developerList)
            {
                count++;
                Console.WriteLine($"{count}. {developer.FullName} {developer.DevID}");
            }
            Console.Write($"Enter the number between 1-{count} for the Developer you want removed: ");
            int targetID = int.Parse(Console.ReadLine());
            int targetIndex = targetID - 1;
            if (targetIndex >= 0 && targetIndex < developerList.Count)
            {
                Developer desiredDevloper = developerList[targetIndex];
                if (_devTeamRepo.DeleteExistingDevInfo(desiredDevloper))
                {
                    Console.WriteLine($"{desiredDevloper.FullName}'s information successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
            else
                Console.WriteLine("No Developer found from given paramters.");
            AnyKey();
        }

        //End of Developer Options
        //Ahead: Development Team Options
        private void DisplayAllDevTeams()
        {
            Console.Clear();

            List<DevTeam> listOfTeams = _devTeamRepo.GetAllTeams();
            foreach (DevTeam dTeam in listOfTeams)
            {
                DisplayTeamInfo(dTeam);
                Console.WriteLine();
            }
            AnyKey();
        }

        private void DisplayTeamByID()
        {
            Console.Clear();
            DisplayTeamIDs();
            Console.WriteLine("Enter the team ID you wish to look at: ");
            int dTeamId = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetDevTeamById(dTeamId);
            if (devTeam != null)
            {
                DisplayTeamInfo(devTeam);
            }
            else
            {
                Console.WriteLine("Could not find existing team by ID.");
            }
            AnyKey();
        }

        private void AddDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter new team information.");
            DevTeam dTeam = new DevTeam();
            Console.Write("Enter Team ID: ");
            dTeam.TeamID = int.Parse(Console.ReadLine());
            Console.Write("Enter Team Name: ");
            dTeam.TeamName = Console.ReadLine();
            if (_devTeamRepo.AddNewDevTeam(dTeam))
            {
                Console.WriteLine("Development Team added successfully.");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Something went wrong, devlopment team not added successfully.");
                AnyKey();
            }
        }
        private void UpdateDevTeam()
        {
            Console.Clear();
            DisplayTeamIDs();
            Console.Write("Enter the ID of the team you want to update: ");
            DevTeam oldTeamInfo = _devTeamRepo.GetDevTeamById(int.Parse(Console.ReadLine()));
            if (oldTeamInfo != null)
            {
                Console.Clear();
                Console.WriteLine("Enter new Team Information, leave blank if unchanged.");
                Console.Write("Team ID: ");
                string teamIdInput = Console.ReadLine();
                if (teamIdInput != "")
                {
                    oldTeamInfo.TeamID = int.Parse(teamIdInput);
                }
                Console.Write("Team Name: ");
                string teamNameInput = Console.ReadLine();
                if (teamNameInput != "")
                {
                    oldTeamInfo.TeamName = teamNameInput;
                }

                Console.WriteLine("Successfully updated Development Team information.");
                AnyKey();
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();
                    Console.WriteLine("Would you like to add/remove developers at this time?\n" +
                        "1. Add Developers to Team\n" +
                        "2. Remove Developers from Team\n" +
                        "3. Return to Menu");
                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            AddDeveloperToTeam();
                            break;
                        case "2":
                            RemoveDeveloperFromTeam();
                            break;
                        case "3":
                        default:
                            continueToRun = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No team by that ID found.");
            }
            AnyKey();
        }
        private void AddDeveloperToTeam()
        {
            Console.Clear();
            DisplayTeamIDs();
            Console.Write("Enter the ID of the Development Team you wish to add to: ");
            int devTeamId = int.Parse(Console.ReadLine());
            ListDevelopersByID();
            Console.Write("Enter the IDs of the Developer you wish to add (Seperate with commas, no spaces): ");
            string input = Console.ReadLine();
            var output = input.Split(',');
            foreach (var devId in output)
            {
                bool wasAdded = _devTeamRepo.AddDeveloperToTeamByID(Int32.Parse(devId), devTeamId);
                if (wasAdded)
                {
                    Console.WriteLine("Developer added successfully.");
                }
                else
                {
                    Console.WriteLine("Somehting went wrong, developer not added.");
                }
            }
            AnyKey();
        }
        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            DisplayTeamIDs();
            Console.Write("Enter the ID of the Development Team you wish to remove developers from: ");
            int devTeamId = int.Parse(Console.ReadLine());
            ListDevelopersByID();
            Console.Write("Enter the IDs of the Developers you wish to remove freo mthe team: ");
            string input = Console.ReadLine();
            var output = input.Split(',');
            foreach (var devId in output)
            {
                bool wasRemoved = _devTeamRepo.RemoveDeveloperToTeamByID(Int32.Parse(devId), devTeamId);
                if (wasRemoved)
                {
                    Console.WriteLine("Developer successfully removed.");
                }
                else
                {
                    Console.WriteLine("Something went wrong, developer not removed.");
                }
            }
            AnyKey();
        }
        private void DeleteExistingDevTeam()
        {
            Console.Clear();
            List<DevTeam> developerTeams = _devTeamRepo.GetAllTeams();
            int count = 0;
            foreach (DevTeam devTeam in developerTeams)
            {
                count++;
                Console.WriteLine($"{count}. {devTeam.TeamID}, {devTeam.TeamName}");
            }
            Console.Write($"Enter the number between 1-{count} of the team you wish to remove: ");
            int targetId = int.Parse(Console.ReadLine());
            int targetIndex = targetId - 1;
            if (targetIndex >= 0 && targetIndex < developerTeams.Count)
            {
                DevTeam desiredTeam = developerTeams[targetIndex];
                if (_devTeamRepo.DeleteExistingDevTeam(desiredTeam))
                {
                    Console.WriteLine($"{desiredTeam.TeamID} {desiredTeam.TeamName} information successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
            else
                Console.WriteLine("No Development Team found by that ID.");
            AnyKey();
        }
        // Helpermethods you should write
        // A method to print a developer's first and last name, useful in display all
        private void DisplayDevBasicInfo(Developer dev)
        {
            Console.WriteLine(dev.FullName);
            Console.WriteLine(dev.DevID);
            Console.WriteLine();
        }

        // A method to print a developers full information, useful when showing one developer
        private void DisplayDevFullInfo(Developer developer)
        {
            Console.WriteLine($"Personal ID: {developer.DevID}\n" +
                $"Full Name: {developer.FullName}\n" +
                $"Email: {developer.Email}\n" +
                $"Phone: {developer.PhoneNumber}\n" +
                $"Specialty: {developer.SkillSet}\n" +
                $"Pluralsight Access Status: {developer.HasAccessToPluralsight}\n");
        }
        public void ListDevelopersByID()  //Helps with User Experience. Other list-all method did not interact nicely, so went with adding something like this
        { //Allows for basic dev info to be recalled to help with sorting complex IDs.
            List<Developer> listofDevelopers = _devTeamRepo.GetAllDevelopers();
            foreach (Developer developer in listofDevelopers)
            {
                DisplayDevBasicInfo(developer);
            }
        }
        private void DisplayTeamIDs() //Same as above, except only gets team IDs, as full team info is rather small
        {
            List<DevTeam> listofIds = _devTeamRepo.GetAllTeams();
            foreach (DevTeam dTeam in listofIds)
            {
                Console.WriteLine($"Team: {dTeam.TeamID}");
            }
        }
        private void DisplayTeamInfo(DevTeam dTeam)
        {
            int count = 0;
            Console.Write($"Development Team ID: {dTeam.TeamID}\n" +
                $"Development Team Name: {dTeam.TeamName}\n");
            Console.WriteLine("Development Team Members: ");
            foreach (Developer devoloper in dTeam.Developers)
            {
                count++;
                Console.WriteLine($"{count}. {devoloper.FullName} {devoloper.DevID} ");
            }
        }
        private void SeedContent()
        {
            Developer devOne = new Developer(341, "John", "Doe", true, SkillSet.FrontEnd, "jdoe@komodo.com", "(317)617-3214");
            Developer devTwo = new Developer(231, "Eugene", "Cogwright", false, SkillSet.BackEnd, "ecogwright@komodo.com", "(482)412-1780");
            Developer devThree = new Developer(342, "Olivia", "Wrigton", false, SkillSet.Testing, "owrigton@komodo.com", "(789)862-1928");

            DevTeam dTeamOne = new DevTeam(112, "Alpha Development");
            DevTeam dTeamTwo = new DevTeam(419, "User Interface");
            _devTeamRepo.AddDeveloper(devOne);
            _devTeamRepo.AddDeveloper(devTwo);
            _devTeamRepo.AddDeveloper(devThree);
            dTeamOne.Developers.Add(devOne);
            dTeamTwo.Developers.Add(devThree);
            _devTeamRepo.AddNewDevTeam(dTeamOne);
            _devTeamRepo.AddNewDevTeam(dTeamTwo);
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }
}

