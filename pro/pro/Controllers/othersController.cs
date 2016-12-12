using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;

namespace pro.Controllers
{
    public class othersController : Controller
    {
        //
        // GET: /furniture/

        dbaseEntities1 db = new dbaseEntities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult furniture()
        {
            List<furniture> furnitures = db.furnitures.ToList();
            return View(furnitures);
        }

    }
}
