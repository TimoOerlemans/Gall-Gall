using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;

namespace drankshop.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Voer een gebruikersnaam in")]
        public string Gebruikersnaam { get; set; }
        [Required(ErrorMessage = "Voer een wachtwoord in")]
        public string Wachtwoord { get; set; }
        public int Id { get; set; }
        public Rollen Rol { get; set; }

        public LogInViewModel(string gebruikersnaam, string wachtwoord)
        {
            this.Gebruikersnaam = gebruikersnaam;
            this.Wachtwoord = wachtwoord;
        }
        public LogInViewModel()
        {

        }
    }
}
