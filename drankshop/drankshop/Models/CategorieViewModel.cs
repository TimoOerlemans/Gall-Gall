using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;

namespace drankshop.Models
{
    public class CategorieViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public CategorieViewModel(Categorie categorie)
        {
            this.Id = categorie.Id;
            this.Naam = categorie.Naam;
        }
        public CategorieViewModel()
        {

        }
    }
}
