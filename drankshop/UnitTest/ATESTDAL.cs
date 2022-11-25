using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Account;
using LOGIC;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ATESTDAL : IAccountContainer
    {
        static public List<AccountDTO> AccountDB = new List<AccountDTO>();

        public ATESTDAL()
        {
            AccountDTO a = new AccountDTO();
            a.Id = 1;
            a.Voornaam = "Test1";
            a.Achternaam = "Test1";
            a.Gebruikersnaam = "Testen";
            a.Wachtwoord = "Wachtwoord";
            a.Leeftijd = DateTime.Now;
            a.Rol = 0;
            AccountDB.Add(a);

            AccountDTO a1 = new AccountDTO();
            a1.Id = 2;
            a1.Voornaam = "Test2";
            a1.Achternaam = "Test2";
            a1.Gebruikersnaam = "Testen2";
            a1.Wachtwoord = "Wachtwoord2";
            a1.Leeftijd = DateTime.Now;
            a1.Rol = 0;
            AccountDB.Add(a1);
        }

        public bool BeschikbaarCheck(AccountDTO accountDTO)
        {
            return !AccountDB.Equals(accountDTO);
        }

        public int Inloggen(string gebruikersnaam, string wachtwoord)
        {
            if(string.IsNullOrEmpty("Testen") || string.IsNullOrEmpty("Wachtwoord"))
            {
                return 0;
            }   
            return 1;
        }

        public int OphalenPerId(int id)
        {
            var ID = AccountDB.First(item => item.Id == id);
            int retu = ID.Id;
            return retu;
        }

        public bool Registreren(AccountDTO accountDTO)
        {
            AccountDB.Add(accountDTO);
            return true;
        }
    }
}
