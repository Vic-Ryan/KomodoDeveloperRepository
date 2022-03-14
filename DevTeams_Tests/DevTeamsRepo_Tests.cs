using DevTeams_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{
    [TestClass]
    public class DevTeamsRepo_Tests
    {
        //protected readonly List<Developer> _devDirectory = new List<Developer>;
        // Testing environment if you need it.
        [TestMethod]
        public void DeveloperShouldBeAdded_ShouldBeTrue()
        {
            Developer dev = new Developer();
            DevRepo repository = new DevRepo();
            bool addResult = repository.AddDeveloper(dev);
            Assert.IsTrue(addResult);
            
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
