using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Drank;
using LOGIC;
using drankshop.Models;
using DAL.Categorie;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace drankshop.Controllers
{
    public class DrankController : Controller
    {
        private DrankContainer drankContainer = new DrankContainer(new DrankDAL());
        private CategorieContainer categorieContainer = new CategorieContainer(new CategorieDAL());

        public IActionResult Index(int? alert)
        {
            List<CategorieViewModel> categories = new List<CategorieViewModel>();
            List<DrankViewModel> models = new List<DrankViewModel>();

            foreach (Drank drank in drankContainer.AlleDranken())
            {
                models.Add(new DrankViewModel(drank));
            }

            foreach (Categorie categorie in categorieContainer.AlleCategorieën())
            {
                categories.Add(new CategorieViewModel(categorie));
            }

            AccountViewModel Gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            Account_DrankViewmodel model = new Account_DrankViewmodel(models, Gebruiker);

            ViewBag.DrankLijst = models;
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
            DrankViewModel drankViewModel = new DrankViewModel();
            List<Categorie> categories = new List<Categorie>();
            foreach (Categorie categorie in categorieContainer.AlleCategorieën())
            {
                Categorie c = new Categorie(categorie.Id, categorie.Naam);
                categories.Add(c);
            }
            drankViewModel.TeKiezenCategorie = categories;
            ViewBag.Alert = alert;
            return View("Aanmaken", drankViewModel);
        }

        [HttpPost]
        public IActionResult Aanmaken(DrankViewModel model)
        {
            try
            {
                if (model.Prijs <= 0)
                {
                    return RedirectToAction("Index", new { alert = 2 });
                }
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index", new { alert = 1 });
                }
                Drank d = new Drank(model.Id, model.Naam, model.Prijs);
                if (!drankContainer.BeschikbaarCheck(d))
                {
                    return RedirectToAction("Index", new { alert = 5 });
                }
                if (HttpContext.Request.Form.Files[0] != null)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    model.Image = file.FileName;
                    using (var fs = new FileStream($"./wwwroot/img/{d.Naam}.jpg", FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                }
                drankContainer.DrankAanmaken(d, model.Id);
                return RedirectToAction("Index", new { alert = 0 });
            }
            catch
            {
                return RedirectToAction("Index", new { alert = 1 });
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
                drankContainer.DrankVerwijderen(id);
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
            Drank drank = drankContainer.DrankPerId(id);
            ViewBag.Drank = drank;

            return View("Bewerken");
        }

        [HttpPost]
        public IActionResult Bewerken(DrankViewModel model)
        {
            try
            {                 
                Drank d = new Drank(model.Id, model.Naam, model.Prijs);
                if (!drankContainer.BeschikbaarCheck(d))
                {
                    return RedirectToAction("Index", new { alert = 5 });
                }
                drankContainer.DrankBewerken(d);
                return RedirectToAction("Index", new { alert = 0 });
            }
            catch
            {
                return RedirectToAction("Index", new { alert = 1 });
            }

        }

        public IActionResult Details(int id)
        {
            AccountViewModel Gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            Categorie categorie = categorieContainer.CategoriePerId(id);
            List<Drank> dranken = drankContainer.DrankPerCategorie(id);
            DrankViewModel models = new DrankViewModel(categorie);
            Account_DrankViewmodel model = new Account_DrankViewmodel(models, Gebruiker);
            ViewBag.Categorieën = categorie;
            ViewBag.Dranken = dranken;
            return View(model);
        }
    }
}
