using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using drankshop.Models;
using DAL.Account;
using LOGIC;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace drankshop.Controllers
{
    public class AccountController : Controller
    {
        private AccountContainer container = new AccountContainer(new AccountDAL());

        [HttpGet]
        public IActionResult Inloggen(int? alert)
        {
            ViewBag.Alert = alert;
            return View();
        }

        public IActionResult Inloggen(LogInViewModel vm)
        {
            if (vm.Gebruikersnaam != null && vm.Wachtwoord != null)
            {
                vm.Id = container.Inloggen(vm.Gebruikersnaam, vm.Wachtwoord);
                if (vm.Id != 0)
                {
                    int rolDB = container.AccountperId(vm.Id);
                    switch (rolDB)
                    {
                        case 0:
                            vm.Rol = Rollen.Gebruiker;
                            break;
                        case 1:
                            vm.Rol = Rollen.Admin;
                            break;
                    }
                    HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(vm));
                    HttpContext.Session.SetInt32("UserID", vm.Id);
                    if(vm.Rol == Rollen.Gebruiker)
                    {
                        return Redirect("/Drank/Index");
                    }
                    else
                    {
                        return Redirect("/Drank/Index");
                    }
                }
                return RedirectToAction("Inloggen", new { alert = 1 });
            }
            return RedirectToAction("Inloggen", new { alet = 3 });
        }

        [HttpGet]
        public IActionResult Registreren(int? alert)
        {
            ViewBag.Alert = alert;
            return View();
        }

        [HttpPost]
        public IActionResult Registreren(AccountViewModel model)
        {
            if (model.Voornaam != null && model.Achternaam != null && model.Gebruikersnaam != null && model.Wachtwoord != null)
            {
                Account a = new Account(model.Voornaam, model.Achternaam, model.Gebruikersnaam, model.Wachtwoord, model.Leeftijd, model.Rol);
                if (!container.BeschikbaarCheck(a))
                {
                    return RedirectToAction("Registreren", new { alert = 5 });
                }
                if (container.Registreren(a))
                {
                    return RedirectToAction("Inloggen", new { alert = 2 });
                }
                return RedirectToAction("Registreren", new { alert = 0 });
            }
            return RedirectToAction("Registreren", new { alert = 1 });
        }

        public IActionResult Uitloggen()
        {
            HttpContext.Session.Remove("UserSession");
            return RedirectToAction("Inloggen");
        }
    }
}
