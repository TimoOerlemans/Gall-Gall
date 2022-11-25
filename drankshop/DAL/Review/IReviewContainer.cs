using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Review
{
    public interface IReviewContainer
    {
        public bool SchrijfReview(ReviewDTO reviewDTO);
        public List<ReviewDTO> ReviewPerAccount(int accountID);
        public List<ReviewDTO> ReviewPerDrank(int drankID);
        public bool VerwijderReview(int id);
    }
}
