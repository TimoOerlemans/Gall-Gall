using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LOGIC;
using DAL.Favoriet;
using drankshop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace drankshop.Controllers
{
    public class FavorietController : Controller
    {
        private FavorietContainer favorietContainer = new FavorietContainer(new FavorietDAL());

        public IActionResult FavorietToevoegen(AccountViewModel vm, int id)
        {
            AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            if (gebruiker.Rol == Rollen.Admin)
            {
                return RedirectToAction("/Drank/Index");
            }
            vm.Id = (int)HttpContext.Session.GetInt32("UserID");
            //if (!favorietContainer.BeschikbaarCheck())
            //{

            //}
            favorietContainer.FavorietToevoegen(id, vm.Id);
            return Redirect("/Drank/Index");
        }

        public IActionResult FavorietenLijst()
        {
            List<FavorietViewModel> vm = new List<FavorietViewModel>();
            int aid = (int)HttpContext.Session.GetInt32("UserID");

            foreach (Favoriet favoriet in favorietContainer.FavorietenLijst(aid))
            {
                vm.Add(new FavorietViewModel(favoriet));
            }
            ViewBag.ReviewList = vm;
            return View(vm);
        }
        public IActionResult Verwijderen()
        {
            try
            {
                int aid = (int)HttpContext.Session.GetInt32("UserID");
                AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

                if (gebruiker.Rol == Rollen.Admin)
                {
                    return RedirectToAction("/Drank/Index");
                }
                favorietContainer.FavorietVerwijderen(aid);
                return RedirectToAction("FavorietenLijst", new { alert = 0 });
            }
            catch
            {
                return RedirectToAction("FavorietenLijst", new { alert = 1 });
            }
        }
    }
}
