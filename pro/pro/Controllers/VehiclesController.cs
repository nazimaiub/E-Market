using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;
using PagedList;
using PagedList.Mvc;


namespace pro.Controllers
{
    public class VehiclesController : Controller
    {
        //
        // GET: /Vehicles/
        dbaseEntities1 db = new dbaseEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Car(int page = 1)
        {

            return View(db.cars.OrderByDescending(x => x.id).ToPagedList(page, 3));
        }


    }
}
