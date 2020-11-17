using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEnterwell.Models;

namespace WebAppEnterwell.Controllers
{
    public class PDVController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Create()
        {
            var model = new PDVCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(PDVCreateViewModel model)
        {
            var newPDV = new PDV()
            {
                Name=model.Name,
                Value=model.Value
            };
            db.PDV.Add(newPDV);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}