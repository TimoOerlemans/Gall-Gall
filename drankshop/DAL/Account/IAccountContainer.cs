using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Account
{
    public interface IAccountContainer
    {
        public bool Registreren(AccountDTO accountDTO);
        public int Inloggen(string gebruikersnaam, string wachtwoord);
        public int OphalenPerId(int id);
        public bool BeschikbaarCheck(AccountDTO accountDTO);
    }
}
