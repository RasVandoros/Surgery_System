using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication2;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Over_Surgery_Unit_Tests
{
    [TestClass]
    public class UserStory2Tests
    {

        /// <summary>
        /// For this method we recreate all the actions performed during the second userstory to test 
        /// the succession of the process. First we register a new patient, and then we look for him using the 
        /// ConfirmPatientClick method, the same method used from the software to Find a Patient. Both overloads of the 
        /// methods are used and the test is successful only if both succeed.
        /// </summary>
        [TestMethod]
        public void RegisterPatientTests()
        {
            //arrange
            string name = "TestName";
            string dob = "2000_01_01";
            string postcode = "cb19bt";

            bool expected = true;

            //act
            UIManager.Instance.RegisterPatient(name, postcode, dob); // register patient
            bool actual1 = UIManager.Instance.ConfirmSearchPatientClick(name, postcode, dob); //look for him
            Patient p = new Patient( UIManager.Instance.LoadPatient(name, postcode, dob)); //create the patient to get the patient id 
            bool actual2 = UIManager.Instance.ConfirmSearchPatientClick(p.PatientId); // for him with the overload using the id
            bool actual = false;
            if(actual1 && actual2) // actual is only true if both the other two searches are true
            {
                actual = true;
            }

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test methods tests the confirm search patient click method by requesting a search for a patient that does not exist in the database
        /// The methods is expected to return false for the test to succeed
        /// </summary>
        [TestMethod]
        public void SearchPatientTest()
        {
            //arrange
            string name = "NonExist";
            string dob = "2000_01_01";
            string postcode = "cb19bt";

            bool expected = false;

            //act
            bool actual = UIManager.Instance.ConfirmSearchPatientClick(name, postcode, dob);
            
          

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
