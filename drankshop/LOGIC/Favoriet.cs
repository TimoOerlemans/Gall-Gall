using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Favoriet;

namespace LOGIC
{
    public class Favoriet
    {
        public Drank Drank;
        public Account Account;
        public Favoriet(FavorietDTO favorietDTO)
        {
            Drank.Id = favorietDTO.DrankID;
            Account.Id = favorietDTO.AccountID;
        }
    }
}
