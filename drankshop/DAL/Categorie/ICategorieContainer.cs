using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Categorie
{
    public interface ICategorieContainer
    {
        public bool CategorieAanmaken(CategorieDTO categorieDTO);
        public List<CategorieDTO> AlleCategorieën();
        public bool CategorieVerwijderen(int id);
        public CategorieDTO OphalenPerId(int id);
        public bool CategorieBewerken(CategorieDTO categorieDTO);
        public bool BeschikbaarCheck(CategorieDTO categorieDTO);
    }
}
