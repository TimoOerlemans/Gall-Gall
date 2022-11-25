using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;

namespace drankshop.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public DateTime Leeftijd { get; set; }
        public Rollen Rol { get; set; }
    }
}