using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using DAL.Drank;
using DAL.Categorie;
using drankshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class DrankContainerTest
    {
        [TestMethod]
        public void DrankVerwijderen()
        {
            //Arrange
            IDrankContainer icontainer = new DTESTDAL();
            DrankContainer drank = new DrankContainer(icontainer);
            var verwacht = DTESTDAL.DrankDB;
            //Act
            var resultaat = drank.DrankVerwijderen(1);

            //Assert
            Assert.IsTrue(resultaat);
        }

        [TestMethod]
        public void DrankAanmaken2()
        {
            //Arrange
            IDrankContainer idrank = new DTESTDAL();
            Drank drank = new Drank(4, "test", -13);
            DrankContainer drankContainer = new DrankContainer(idrank);
            var verwacht = DTESTDAL.DrankDB;

            //Act
            bool resultaat = drankContainer.DrankAanmaken(drank, 1);

            //Assert
            Assert.IsFalse(resultaat);
        }

        [TestMethod]
        public void AlleDranken()
        {
            //Arrange
            IDrankContainer idrank = new DTESTDAL();
            DrankContainer container = new DrankContainer(idrank);
            var verwacht = DTESTDAL.DrankDB;

            //Act
            var resultaat = container.AlleDranken();

            //Assert
            Assert.AreEqual(verwacht.Last().Id, resultaat.Last().Id);
            Assert.AreEqual(verwacht.Last().Naam, resultaat.Last().Naam);
            Assert.AreEqual(verwacht.Last().Prijs, resultaat.Last().Prijs);
        }

        [TestMethod]
        public void DrankAanmaken()
        {
            //Arrange
            IDrankContainer idrank = new DTESTDAL();
            Drank drank = new Drank(6, "test", 15);
            DrankContainer drankContainer = new DrankContainer(idrank);

            DrankDTO verwacht = new DrankDTO();
            verwacht.Id = 6;
            verwacht.Naam = "test";
            verwacht.Prijs = 15;
            verwacht.CategorieId = 4;

            //Act

            bool resultaat = drankContainer.DrankAanmaken(drank, 4);

            //Assert
            Assert.IsTrue(resultaat);
            Assert.AreEqual(verwacht.Naam, DTESTDAL.DrankDB.Last().Naam);
            Assert.AreEqual(verwacht.Prijs, DTESTDAL.DrankDB.Last().Prijs);
            Assert.AreEqual(verwacht.CategorieId, DTESTDAL.DrankDB.Last().CategorieId);
        }

        [TestMethod]
        public void DrankPerId()
        {
            //Arrange
            IDrankContainer icontainer = new DTESTDAL();
            DrankContainer container = new DrankContainer(icontainer);
            var verwacht = DTESTDAL.DrankDB.First(item => item.Id == 1);

            //Act
            var resultaat = container.DrankPerId(1);

            //Assert
            Assert.AreEqual(verwacht.Id, resultaat.Id);
            Assert.AreEqual(verwacht.Naam, resultaat.Naam);
            Assert.AreEqual(verwacht.Prijs, resultaat.Prijs);
        }

        [TestMethod]
        public void DrankPerCategorie()
        {
            //Arrange
            IDrankContainer icontainer = new DTESTDAL();
            DrankContainer drank = new DrankContainer(icontainer);
            var verwacht = DTESTDAL.DrankDB;

            //Act
            var resultaat = drank.DrankPerCategorie(3);

            //Assert
            Assert.AreEqual(verwacht.Last().Id, resultaat.Last().Id);
            Assert.AreEqual(verwacht.Last().Naam, resultaat.Last().Naam);
            Assert.AreEqual(verwacht.Last().Prijs, resultaat.Last().Prijs);
        }

        [TestMethod]
        public void Bewerken1()
        {
            //Arrange
            IDrankContainer drankContainer = new DTESTDAL();
            Drank drank = new Drank(1, "test5", 5);
            DrankContainer container = new DrankContainer(drankContainer);

            //act
            var result = container.DrankBewerken(drank);

            //assert
            Assert.IsTrue(result);
            Assert.AreEqual(drank.Id, DTESTDAL.DrankDB.Last().Id);
            Assert.AreEqual(drank.Naam, DTESTDAL.DrankDB.Last().Naam);
        }

        [TestMethod]
        public void Bewerken2()
        {
            //Arrange
            IDrankContainer drankContainer = new DTESTDAL();
            Drank drank = new Drank(2, "test", -10);
            DrankContainer container = new DrankContainer(drankContainer);

            DrankDTO verwacht = new DrankDTO();
            verwacht.Id = 2;
            verwacht.Naam = "test1";
            verwacht.Prijs = 15;

            //Act
            var result = container.DrankBewerken(drank);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Beschikbaarcheck()
        {
            //arrange
            IDrankContainer icontainer = new DTESTDAL();
            DrankContainer container = new DrankContainer(icontainer);
            Drank drank = new Drank(5, "bavaria", 3);

            //act
            var resultaat = container.BeschikbaarCheck(drank);

            //assert
            Assert.IsTrue(resultaat);
        }
    }
}
