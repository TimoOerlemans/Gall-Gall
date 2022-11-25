using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Review;

namespace LOGIC
{
    public class Review
    {
        public int Id { get; set; }
        public int Cijfer { get; set; }
        public string Beschrijving { get; set; }
        
        public Review(ReviewDTO reviewDTO)
        {
            this.Id = reviewDTO.Id;
            this.Beschrijving = reviewDTO.Beschrijving;
            this.Cijfer = reviewDTO.Cijfer;
        }

        public Review(int id, string beschrijving, int cijfer)
        {
            Id = id;
            Beschrijving = beschrijving;
            Cijfer = cijfer;
        }
    }
}
