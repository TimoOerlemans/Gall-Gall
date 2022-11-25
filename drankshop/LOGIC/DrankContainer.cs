using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Categorie;
using DAL.Drank;

namespace LOGIC
{
    public class DrankContainer
    {
        private IDrankContainer Icontainer;

        public DrankContainer(IDrankContainer Icontainer)
        {
            this.Icontainer = Icontainer;
        }

        public List<Drank> AlleDranken()
        {
            List<Drank> dranken = new List<Drank>();
            foreach (DrankDTO drankDTO in Icontainer.AlleDranken())
            {
                Drank drank = new Drank(drankDTO.Id, drankDTO.Naam, drankDTO.Prijs);
                dranken.Add(drank);
            }
            return dranken;
        }

        public bool DrankBewerken(Drank drank)
        {
            if (drank.Prijs <= 0)
            {
                return false;
            }
            else
            {
                DrankDTO drankDTO = new DrankDTO();
                drankDTO.Id = drank.Id;
                drankDTO.Naam = drank.Naam;
                drankDTO.Prijs = drank.Prijs;
                return Icontainer.DrankBewerken(drankDTO);
            }
        }
        public bool BeschikbaarCheck(Drank drank)
        {
            DrankDTO drankDTO = new DrankDTO();
            drankDTO.Id = drank.Id;
            drankDTO.Naam = drank.Naam;
            drankDTO.Prijs = drank.Prijs;
            return Icontainer.BeschikbaarCheck(drankDTO);
        }
        public bool DrankAanmaken(Drank drank, int id)
        {
            if(drank.Prijs <= 0)
            {
                return false;
            }
            DrankDTO drankDTO = new DrankDTO();
            drankDTO.Naam = drank.Naam;
            drankDTO.Prijs = drank.Prijs;
            drankDTO.CategorieId = id;
            return Icontainer.DrankAanmaken(drankDTO);
        }

        public bool DrankVerwijderen(int id)
        {
            return Icontainer.DrankVerwijderen(id);
        }

        public Drank DrankPerId(int id)
        {
            DrankDTO drankDTO = Icontainer.DrankPerId(id);
            Drank drank = new(drankDTO.Id, drankDTO.Naam, drankDTO.Prijs);
            return drank;
        }
        public List<Drank> DrankPerCategorie(int id)
        {
            List<Drank> dranks = new List<Drank>();
            foreach (DrankDTO drankDTO in Icontainer.DrankPerCategorie(id))
            {
                Drank drank = new Drank(drankDTO.Id, drankDTO.Naam, drankDTO.Prijs);
                dranks.Add(drank);
            }
            return dranks;
        }
    }
}
