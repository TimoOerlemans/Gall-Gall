using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using drankshop.Models;
using LOGIC;
using DAL.Categorie;
using DAL.Drank;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace drankshop.Controllers
{
    public class CategorieController : Controller
    {
        private CategorieContainer categorieContainer = new CategorieContainer(new CategorieDAL());

        public IActionResult Index(int? alert)
        {
            AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

            if (gebruiker.Rol == Rollen.Gebruiker)
            {
                return RedirectToAction("/Drank/Index");
            }
            List<CategorieViewModel> categories = new List<CategorieViewModel>();
            foreach (Categorie categorie in categorieContainer.AlleCategorieën())
            {
                categories.Add(new CategorieViewModel(categorie));
            }
            AccountViewModel Gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

            Account_CategorieViewModel model = new Account_CategorieViewModel(categories, Gebruiker);
            ViewBag.Categories = categories;
            ViewBag.Alert = alert;
            return View(model);
        }

        [HttpGet]
        public IActionResult Aanmaken(int? alert)
        {
            AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

            if (gebruiker.Rol == Rollen.Gebruiker)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Alert = alert;
            return View();
        }

        [HttpPost]
        public IActionResult Aanmaken(CategorieViewModel model)
        {
            try
            {
                if (model.Naam == null)
                {
                    return RedirectToAction("Index", new { alert = 3 });
                }
                Categorie c = new Categorie(model.Id, model.Naam);
                if (!categorieContainer.BeschikbaarCheck(c))
                {
                    return RedirectToAction("Index", new { alert = 5 });
                }
                categorieContainer.CategorieAanmaken(c);
                return RedirectToAction("Index", new { alert = 0 });
            }
            catch
            {
                return RedirectToAction("Index", new { alert = 2 });
            }
        }

        public IActionResult Verwijderen(int id)
        {
            try
            {
                AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

                if (gebruiker.Rol == Rollen.Gebruiker)
                {
                    return RedirectToAction("Index");
                }
                categorieContainer.CategorieVerwijderen(id);
                return RedirectToAction("Index", new { alert = 0 });
            }
            catch
            {
                return RedirectToAction("Index", new { alert = 1 });
            }
        }

        [HttpGet]
        public IActionResult Bewerken(int id)
        {
            AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

            if (gebruiker.Rol == Rollen.Gebruiker)
            {
                return RedirectToAction("Index");
            }
            Categorie categorie = categorieContainer.CategoriePerId(id);
            ViewBag.Categorie = categorie;
            return View("Bewerken");
        }

        [HttpPost]
        public IActionResult Bewerken(CategorieViewModel model)
        {

            if (model.Naam == null)
            {
                return RedirectToAction("Index", new { alert = 2 });
            }
            else
            {
                try
                {
                    Categorie c = new Categorie(model.Id, model.Naam);
                    if (!categorieContainer.BeschikbaarCheck(c))
                    {
                        return RedirectToAction("Index", new { alert = 5 });
                    }
                    categorieContainer.CategorieBerwerken(c);
                    return RedirectToAction("Index", new { alert = 0 });
                }
                catch
                {
                    return RedirectToAction("Index", new { alert = 1 });
                }
            }
        }
    }
}
