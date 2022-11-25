using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Categorie;
using LOGIC;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTest
{
    [TestClass]
    public class CTESTDAL : ICategorieContainer
    {
        static public List<CategorieDTO> CategorieDB = new List<CategorieDTO>();

        public CTESTDAL()
        {
            CategorieDTO c = new CategorieDTO();
            c.Id = 1;
            c.Naam = "test";

            CategorieDB.Add(c);

            CategorieDTO c1 = new CategorieDTO();
            c1.Id = 2;
            c1.Naam = "test1";

            CategorieDB.Add(c1);
        }

        public List<CategorieDTO> AlleCategorieën()
        {
            return CategorieDB;
        }

        public bool BeschikbaarCheck(CategorieDTO categorieDTO)
        {
            return !CategorieDB.Equals(categorieDTO);
        }

        public bool CategorieAanmaken(CategorieDTO categorieDTO)
        {
            CategorieDB.Add(categorieDTO);
            return true;
        }

        public bool CategorieBewerken(CategorieDTO categorieDTO)
        {
            var categorie = CategorieDB.First(item => item.Id == categorieDTO.Id);
            CategorieDB.Remove(categorie);
            CategorieDB.Add(categorieDTO);
            return true;
        }

        public bool CategorieVerwijderen(int id)
        {
            var index = CategorieDB.First(item => item.Id == id);
            CategorieDB.Remove(index);
            return true;
        }

        public CategorieDTO OphalenPerId(int id)
        {
            return CategorieDB.First(item => item.Id == id);
        }
    }
}
