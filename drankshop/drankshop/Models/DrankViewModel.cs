using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;
using Microsoft.AspNetCore.Http;

namespace drankshop.Models
{
    public class DrankViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }


        public string Image { get; set; }
        public string CategorieNaam { get; set; }
        public List<Categorie> TeKiezenCategorie { get; set; }
        public DrankViewModel(Drank drank)
        {
            this.Id = drank.Id;
            this.Naam = drank.Naam;
            this.Prijs = drank.Prijs;
        }
        public DrankViewModel(Categorie categorie)
        {
            this.CategorieNaam = categorie.Naam;
        }

        public DrankViewModel()
        {
        }
        //public DrankViewModel(int id, string naam, decimal prijs)
        //{
        //    Id = id;
        //    Naam = naam;
        //    Prijs = prijs;
        //}
    }
}