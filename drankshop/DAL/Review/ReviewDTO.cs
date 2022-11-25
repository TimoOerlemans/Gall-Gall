using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Review
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int Cijfer { get; set; }
        public string Beschrijving { get; set; }
        public int AccountID { get; set; }
        public int DrankID { get; set; }
    }
}
