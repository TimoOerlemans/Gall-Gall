 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Categorie;
using DAL.Drank;

namespace LOGIC
{
    public class Categorie
    {

        public int Id { get; private set; }
        public string Naam { get; private set; }
        public Categorie(int id, string naam)
        {
            this.Id = id;
            this.Naam = naam;
        }
    }
}
