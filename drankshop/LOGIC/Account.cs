using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Account;

namespace LOGIC
{
    public class Account
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public DateTime Leeftijd { get; set; }
        public Rollen Rol { get; set; }

        public Account(string voornaam, string achternaam, string gebruikersnaam, string wachtwoord, DateTime leeftijd, Rollen rol)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.Gebruikersnaam = gebruikersnaam;
            this.Wachtwoord = wachtwoord;
            this.Leeftijd = leeftijd;
            this.Rol = rol;
        }
    }
}
