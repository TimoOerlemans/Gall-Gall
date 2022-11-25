using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;

namespace drankshop.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        public int Cijfer { get; set; }

        public ReviewViewModel(Review review)
        {
            this.Id = review.Id;
            this.Beschrijving = review.Beschrijving;
            this.Cijfer = review.Cijfer;
        }
        public ReviewViewModel()
        {

        }
        public string Naam { get; set; }

        public int accountid { get; set; }
    }
}
