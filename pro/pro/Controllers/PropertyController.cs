using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;

namespace pro.Controllers
{
    public class PropertyController : Controller
    {
        //
        // GET: /House/
        dbaseEntities1 db = new dbaseEntities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult House()
        {
            List<house> houses = db.houses.ToList();
            return View(houses);
        }
        public ActionResult land()
        {
            List<land> lands = db.lands.ToList();
            return View(lands);
        }

    }
}
