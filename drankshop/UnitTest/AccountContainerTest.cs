using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using DAL.Account;
using drankshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class AccountContainerTest
    {
        [TestMethod]
        public void Registreren()
        {
            IAccountContainer icontainer = new ATESTDAL();
            Account account = new Account("Piet", "Hendrik", "pietje20", "hendrik123!", DateTime.Now, 0);
            AccountContainer container = new AccountContainer(icontainer);
            
            //act
            var resultaat = container.Registreren(account);

            //Assert
            Assert.IsTrue(resultaat);
        }

        /// <summary>
        /// zelfde gegevens gebruiken of checken in de testmethod 
        /// </summary>

        [TestMethod]
        public void Inloggen()
        {
            //arrange
            IAccountContainer icontainer = new ATESTDAL();
            AccountContainer container = new AccountContainer(icontainer);

            //act
            var resultaat = container.Inloggen("pietje20", "hendrik123!");

            //assert
            Assert.IsNotNull(resultaat);
        }

        [TestMethod]
        public void Beschikbaarcheck()
        {
            //arrange
            IAccountContainer icontainer = new ATESTDAL();         
            AccountContainer container = new AccountContainer(icontainer);
            Account account = new Account("Test1", "Test1", "Piet", "hendrik123!", DateTime.Now, Rollen.Gebruiker);

            //act
            var resultaat = container.BeschikbaarCheck(account);

            //assert
            Assert.IsTrue(resultaat);
        }

        [TestMethod]
        public void AccountPerid()
        {
            //Arrange
            IAccountContainer icontainer = new ATESTDAL();
            AccountContainer container = new AccountContainer(icontainer);

            //Act
            var resultaat = container.AccountperId(1);

            //Assert
            Assert.AreEqual(resultaat, ATESTDAL.AccountDB.First().Id);
        }
    }
}