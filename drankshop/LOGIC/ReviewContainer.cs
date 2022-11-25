using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Review;

namespace LOGIC
{
    public class ReviewContainer
    {
        private IReviewContainer icontainer;

        public ReviewContainer(IReviewContainer icontainer)
        {
            this.icontainer = icontainer;
        }

        public bool SchrijfReview(Review review, int id, int accountid)
        {
            ReviewDTO reviewDTO = new ReviewDTO();
            reviewDTO.Beschrijving = review.Beschrijving;
            reviewDTO.Cijfer = review.Cijfer;
            reviewDTO.DrankID = id;
            reviewDTO.AccountID = accountid;
            return icontainer.SchrijfReview(reviewDTO);
        }
        public List<Review> ReviewperAccount(int id)
        {
            List<Review> reviews = new List<Review>();
            foreach(ReviewDTO reviewDTO in icontainer.ReviewPerAccount(id))
            {
                Review review = new Review(reviewDTO.Id, reviewDTO.Beschrijving, reviewDTO.Cijfer);
                reviews.Add(review);
            }
            return reviews;
        }
        public List<Review> ReviewsperDrank(int id)
        {
            List<Review> reviews = new List<Review>();
            foreach (ReviewDTO reviewDTO in icontainer.ReviewPerDrank(id))
            {
                Review review = new Review(reviewDTO);
                reviews.Add(review);
            }
            return reviews;
        }
        public bool VerwijderReview(int id)
        {
            return icontainer.VerwijderReview(id);
        }
    }
}
