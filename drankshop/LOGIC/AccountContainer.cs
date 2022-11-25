using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Account;
using Scrypt;

namespace LOGIC
{
    public class AccountContainer
    {
        private IAccountContainer iAccountcontainer;

        public AccountContainer(IAccountContainer iaccountcontainer)
        {
            iAccountcontainer = iaccountcontainer;
        }

        public bool Registreren(Account account)
        {
            AccountDTO accountDTO = new AccountDTO();
            accountDTO.Voornaam = account.Voornaam;
            accountDTO.Achternaam = account.Achternaam;
            accountDTO.Gebruikersnaam = account.Gebruikersnaam;
            accountDTO.Wachtwoord = account.Wachtwoord;
            accountDTO.Leeftijd = account.Leeftijd;
            accountDTO.Rol = account.Rol;
            return iAccountcontainer.Registreren(accountDTO);
        }

        public int AccountperId(int id)
        {
            return iAccountcontainer.OphalenPerId(id);
        }

        public int Inloggen(string gebruikersnaam, string wachtwoord)
        {
            return iAccountcontainer.Inloggen(gebruikersnaam, wachtwoord);
        }
        public bool BeschikbaarCheck(Account account)
        {
            AccountDTO accountDTO = new AccountDTO();
            accountDTO.Voornaam = account.Voornaam;
            accountDTO.Achternaam = account.Achternaam;
            accountDTO.Gebruikersnaam = account.Gebruikersnaam;
            accountDTO.Wachtwoord = account.Wachtwoord;
            accountDTO.Leeftijd = account.Leeftijd;
            return iAccountcontainer.BeschikbaarCheck(accountDTO);
        }
    }
}