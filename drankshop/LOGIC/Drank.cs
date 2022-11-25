using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Drank;

namespace LOGIC
{
    public class Drank
    {

        public int Id { get; set; }
        public string Naam { get; private set; }
        public decimal Prijs { get; private set; }

        public Drank(int id, string naam, decimal prijs)
        {
            this.Id = id;
            this.Naam = naam;
            this.Prijs = prijs;
        }
    }
}
