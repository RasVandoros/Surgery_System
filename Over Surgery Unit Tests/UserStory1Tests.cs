using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication2;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Over_Surgery_Unit_Tests
{
    [TestClass]
    public class UserStory1Tests
    {

        /// <summary>
        /// This methods tests the ability of the software to check if a username exists in the database
        /// </summary>
        [TestMethod]
        public void testLogIn()
        {
            //arrange
            string username = "Ras";
            string password = "6908";
            bool expected = true;

            //act
            bool actual = UIManager.Instance.ClickLogIn(username, password);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This methods tests the ability of the software to register a new user
        /// </summary>
        [TestMethod]
        public void testRegisterUser()
        {
            //arrange
            string username = "Paul";
            string password = "55";
            Job jobTitle = Job.Receptionist;

            bool expected = true;

            //act
            UIManager.Instance.RegisterUser(username, password, jobTitle.ToString());
            bool actual = UIManager.Instance.ClickLogIn(username, password);



            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
