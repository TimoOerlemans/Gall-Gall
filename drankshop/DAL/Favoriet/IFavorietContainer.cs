using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Favoriet
{
    public interface IFavorietContainer
    {
        public bool FavorietToevoegen(FavorietDTO favorietDTO);
        public List<FavorietDTO> FavorietenLijst(int accountID);
        public bool VerwijderFavoriet(int id);
    }
}
