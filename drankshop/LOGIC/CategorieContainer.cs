using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Categorie;
using DAL;
using DAL.Drank;

namespace LOGIC
{
    public class CategorieContainer
    {
        private ICategorieContainer container;

        public CategorieContainer(ICategorieContainer container)
        {
            this.container = container;
        }

        public List<Categorie> AlleCategorieën()
        {
            List<Categorie> categories = new List<Categorie>();
            foreach (CategorieDTO categorieDTO in container.AlleCategorieën())
            {
                Categorie categorie = new Categorie(categorieDTO.Id, categorieDTO.Naam);
                categories.Add(categorie);
            }
            return categories;
        }
        public bool BeschikbaarCheck(Categorie categorie)
        {
            CategorieDTO categorieDTO = new CategorieDTO();
            categorieDTO.Naam = categorie.Naam;
            return container.BeschikbaarCheck(categorieDTO);
        }
        public bool CategorieBerwerken(Categorie categorie)
        {
            CategorieDTO categorieDTO = new CategorieDTO();
            categorieDTO.Id = categorie.Id;
            categorieDTO.Naam = categorie.Naam;
            return container.CategorieBewerken(categorieDTO);
        }

        public bool CategorieAanmaken(Categorie categorie)
        {
            CategorieDTO categorieDTO = new CategorieDTO();
            categorieDTO.Naam = categorie.Naam;
            return container.CategorieAanmaken(categorieDTO);
        }

        public bool CategorieVerwijderen(int id)
        {
            return container.CategorieVerwijderen(id);
        }

        public Categorie CategoriePerId(int id)
        {
            CategorieDTO categorieDTO = container.OphalenPerId(id);
            Categorie categorie = new(categorieDTO.Id, categorieDTO.Naam);
            return categorie;
        }
    }
}
