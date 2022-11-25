using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Drank;
using LOGIC;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class DTESTDAL : IDrankContainer
    {
        static public List<DrankDTO> DrankDB = new List<DrankDTO>();

        public DTESTDAL()
        {
            DrankDTO d = new DrankDTO();
            d.Id = 1;
            d.Naam = "test";
            d.Prijs = 13;
            d.CategorieId = 1;
            DrankDB.Add(d);

            DrankDTO d1 = new DrankDTO();
            d1.Id = 2;
            d1.Naam = "test1";
            d1.Prijs = 14;
            d1.CategorieId = 3;
            DrankDB.Add(d1);
        }

        public bool DrankVerwijderen(int id)
        {
            var index = DrankDB.First(item => item.Id == id);
            DrankDB.Remove(index);
            return true;
        }

        public bool DrankAanmaken(DrankDTO drankDTO)
        {
            DrankDB.Add(drankDTO);
            return true;
        }
        public List<DrankDTO> AlleDranken()
        {
            return DrankDB;
        }

        public bool BeschikbaarCheck(DrankDTO drankDTO)
        {
            return !DrankDB.Equals(drankDTO);           
        }


        public bool DrankBewerken(DrankDTO drankDTO)
        {
            var drank = DrankDB.Last(item => item.Id == drankDTO.Id);
            DrankDB.Remove(drank);
            DrankDB.Add(drankDTO);
            return true;
        }

        public List<DrankDTO> DrankPerCategorie(int categorieId)
        {
            return DrankDB.FindAll(item => item.CategorieId == categorieId);
        }

        public DrankDTO DrankPerId(int id)
        {
            return DrankDB.First(item => item.Id == id);
        }
    }
}
