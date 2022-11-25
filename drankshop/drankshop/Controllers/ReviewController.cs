using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using drankshop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using LOGIC;
using DAL.Review;

namespace drankshop.Controllers
{
    public class ReviewController : Controller
    {

        private ReviewContainer reviewContainer = new ReviewContainer(new ReviewDAL());

        [HttpGet]
        public IActionResult SchrijfReview(int? alert)
        {
            AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            if (gebruiker.Rol == Rollen.Admin)
            {
                return RedirectToAction("/Drank/Index");
            }
            ViewBag.Alert = alert;
            return View();
        }

        [HttpPost]
        public IActionResult SchrijfReview(ReviewViewModel vm, int id)
        {
            try
            {
                vm.accountid = (int)HttpContext.Session.GetInt32("UserID");
                if (vm.Beschrijving == null || vm.Cijfer <= 0)
                {
                    return RedirectToAction("SchrijfReview", new { alert = 3 });
                }
                Review review = new Review(vm.Id, vm.Beschrijving, vm.Cijfer);
                reviewContainer.SchrijfReview(review, id, vm.accountid);
                return Redirect("/Drank/Index");
            }
            catch
            {
                return RedirectToAction("Drank", new { alert = 2 });
            }
        }

        public IActionResult ReviewsPerAccount()
        {
            List<ReviewViewModel> vm = new List<ReviewViewModel>();
            int aid = (int)HttpContext.Session.GetInt32("UserID");
    
            foreach (Review review in reviewContainer.ReviewperAccount(aid))
            {
                vm.Add(new ReviewViewModel(review));
            }
            ViewBag.ReviewList = vm;
            return View(vm);
        }

        public IActionResult ReviewsPerDrank(int id)
        {
            List<ReviewViewModel> vm = new List<ReviewViewModel>();
            foreach (Review review in reviewContainer.ReviewsperDrank(id))
            {
                vm.Add(new ReviewViewModel(review));
            }
            ViewBag.ReviewList = vm;
            return View(vm);
        }

        public IActionResult Verwijderen(int id)
        {
            try
            {
                AccountViewModel gebruiker = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

                if (gebruiker.Rol == Rollen.Admin)
                {
                    return RedirectToAction("/Drank/Index");
                }
                reviewContainer.VerwijderReview(id);
                return RedirectToAction("ReviewsPerAccount", new { alert = 0 });
            }
            catch
            {
                return RedirectToAction("ReviewsPerAccount", new { alert = 1 });
            }
        }
    }
}
