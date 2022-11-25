using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using DAL.Review;
using drankshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ReviewContainerTest
    {
        [TestMethod]
        public void Verwijderreview()
        {
            //Arrange
            IReviewContainer icontainer = new RTESTDAL();
            ReviewContainer review = new ReviewContainer(icontainer);
            var verwacht = RTESTDAL.ReviewDB;

            //Act
            var resultaat = review.VerwijderReview(1);

            //Assert
            Assert.IsTrue(resultaat);
            //Assert.AreEqual(1, verwacht.Count);
        }
        [TestMethod]
        public void Reviewsperaccount()
        {
            //Arrange
            IReviewContainer icontainer = new RTESTDAL();
            ReviewContainer review = new ReviewContainer(icontainer);
            var verwacht = RTESTDAL.ReviewDB;

            //Act
            var resultaat = review.ReviewperAccount(2);

            //Assert
            Assert.AreEqual(verwacht.Last().Id, resultaat.Last().Id);
            Assert.AreEqual(verwacht.Last().Beschrijving, resultaat.Last().Beschrijving);
            Assert.AreEqual(verwacht.Last().Cijfer, resultaat.Last().Cijfer);
        }

        [TestMethod]
        public void Reviewsperdrank()
        {
            //Arrange
            IReviewContainer icontainer = new RTESTDAL();
            ReviewContainer review = new ReviewContainer(icontainer);
            var verwacht = RTESTDAL.ReviewDB;

            //Act
            var resultaat = review.ReviewsperDrank(2);

            //Assert
            Assert.AreEqual(verwacht.Last().Id, resultaat.Last().Id);
            Assert.AreEqual(verwacht.Last().Beschrijving, resultaat.Last().Beschrijving);
            Assert.AreEqual(verwacht.Last().Cijfer, resultaat.Last().Cijfer);
        }

        [TestMethod]
        public void schrijfreview()
        {
            //Arrange
            IReviewContainer ireview = new RTESTDAL();
            Review review = new Review(1, "test", 3);
            ReviewContainer reviewContainer = new ReviewContainer(ireview);

            ReviewDTO verwacht = new ReviewDTO();
            verwacht.Id = 3;
            verwacht.Beschrijving = "test";
            verwacht.Cijfer = 3;
            verwacht.AccountID = 4;
            verwacht.DrankID = 4;

            //Act

            bool resultaat = reviewContainer.SchrijfReview(review, 4, 4);

            //Assert
            Assert.IsTrue(resultaat);
            Assert.AreEqual(verwacht.Beschrijving, RTESTDAL.ReviewDB.Last().Beschrijving);
            Assert.AreEqual(verwacht.Cijfer, RTESTDAL.ReviewDB.Last().Cijfer);
            Assert.AreEqual(verwacht.AccountID, RTESTDAL.ReviewDB.Last().AccountID);
            Assert.AreEqual(verwacht.DrankID, RTESTDAL.ReviewDB.Last().DrankID);
        }
    }
}
