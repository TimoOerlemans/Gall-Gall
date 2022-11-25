using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Favoriet;

namespace LOGIC
{
    public class FavorietContainer
    {
        private IFavorietContainer icontainer;

        public FavorietContainer(IFavorietContainer ifavoriet)
        {
            this.icontainer = ifavoriet;
        }
        public bool FavorietToevoegen(int id, int accountid)
        {
            FavorietDTO favorietDTO = new FavorietDTO();
            favorietDTO.DrankID = id;
            favorietDTO.AccountID = accountid;
            return icontainer.FavorietToevoegen(favorietDTO);
        }
        public List<Favoriet> FavorietenLijst(int accountid)
        {
            List<Favoriet> favoriets = new List<Favoriet>();
            foreach (FavorietDTO favorietDTO in icontainer.FavorietenLijst(accountid))
            {
                Favoriet favoriet = new Favoriet(favorietDTO);
                favoriets.Add(favoriet);
            }
            return favoriets;
        }
        public bool FavorietVerwijderen(int id)
        {
            return icontainer.VerwijderFavoriet(id);
        }
    }
}
