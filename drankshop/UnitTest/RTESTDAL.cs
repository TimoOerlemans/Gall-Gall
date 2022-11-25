using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC;
using DAL.Review;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class RTESTDAL : IReviewContainer
    {
        static public List<ReviewDTO> ReviewDB = new List<ReviewDTO>();

        public RTESTDAL()
        {
            ReviewDTO r = new ReviewDTO();
            r.Id = 1;
            r.Beschrijving = "Lekker bier";
            r.Cijfer = 3;
            r.AccountID = 1;
            r.DrankID = 1;
            ReviewDB.Add(r);

            ReviewDTO r1 = new ReviewDTO();
            r1.Id = 2;
            r1.Beschrijving = "Lekker bier";
            r1.Cijfer = 4;
            r1.AccountID = 2;
            r1.DrankID = 2;
            ReviewDB.Add(r1);
        }

        public List<ReviewDTO> ReviewPerAccount(int accountID)
        {
            return ReviewDB.FindAll(item => item.AccountID == accountID);
        }

        public List<ReviewDTO> ReviewPerDrank(int drankID)
        {
            return ReviewDB.FindAll(item => item.DrankID == drankID);
        }

        public bool SchrijfReview(ReviewDTO reviewDTO)
        {
            ReviewDB.Add(reviewDTO);
            return true;
        }

        public bool VerwijderReview(int id)
        {
            var index = ReviewDB.First(item => item.Id == id);
            ReviewDB.Remove(index);
            return true;
        }
    }
}
