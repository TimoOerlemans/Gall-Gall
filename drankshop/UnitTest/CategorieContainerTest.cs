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
    public class CategorieContainerTest
    {
        [TestMethod]
        public void AlleCategoriën()
        {
            //Arrange
            ICategorieContainer icontainer = new CTESTDAL();
            CategorieContainer container = new CategorieContainer(icontainer);
            var verwacht = CTESTDAL.CategorieDB;

            //Act
            var resultaat = container.AlleCategorieën();

            //Assert
            Assert.AreEqual(verwacht.Last().Id, resultaat.Last().Id);
            Assert.AreEqual(verwacht.Last().Naam, resultaat.Last().Naam);
            Assert.AreEqual(2, verwacht.Count);
        }
        [TestMethod]
        public void Bewerken()
        {
            //Arrange
            ICategorieContainer icategorie = new CTESTDAL();
            Categorie categorie = new Categorie(1, "test12");
            CategorieContainer container = new CategorieContainer(icategorie);

            CategorieDTO verwacht = new CategorieDTO();
            verwacht.Id = 1;
            verwacht.Naam = "test12";

            //act
            var result = container.CategorieBerwerken(categorie);

            //assert
            Assert.IsTrue(result);
            Assert.AreEqual(verwacht, CTESTDAL.CategorieDB.Last());
        }
        [TestMethod]
        public void CategorieAanmaken()
        {
            //Arrange
            ICategorieContainer idrank = new CTESTDAL();
            CategorieContainer container = new CategorieContainer(idrank);
            Categorie categorie = new Categorie(16, "test16");

            CategorieDTO verwacht = new CategorieDTO();
            verwacht.Id = 16;
            verwacht.Naam = "test16";

            //Act
            bool resultaat = container.CategorieAanmaken(categorie);

            //Assert
            Assert.IsTrue(resultaat);
            Assert.AreEqual(verwacht.Naam, CTESTDAL.CategorieDB.Last().Naam);
        }

        [TestMethod]
        public void CategorieVerwijderen()
        {
            //Arrange
            ICategorieContainer icontainer = new CTESTDAL();
            CategorieContainer container = new CategorieContainer(icontainer);

            //Act
            var resultaat = container.CategorieVerwijderen(1);

            //Assert
            Assert.IsTrue(resultaat);
           
        }

        [TestMethod]
        public void CategoriePerId()
        {
            //Arrange
            ICategorieContainer icontainer = new CTESTDAL();
            CategorieContainer container = new CategorieContainer(icontainer);
            var verwacht = CTESTDAL.CategorieDB.First(item => item.Id == 1);

            //Act
            var resultaat = container.CategoriePerId(1);

            //Assert
            Assert.AreEqual(verwacht.Id, resultaat.Id);
            Assert.AreEqual(verwacht.Naam, resultaat.Naam);
        }
        [TestMethod]
        public void Beschikbaarcheck()
        {
            //arrange
            ICategorieContainer icontainer = new CTESTDAL();
            CategorieContainer container = new CategorieContainer(icontainer);
            Categorie categorie = new Categorie(5, "bavaria");

            //act
            var resultaat = container.BeschikbaarCheck(categorie);

            //assert
            Assert.IsTrue(resultaat);
        }
    }
}
