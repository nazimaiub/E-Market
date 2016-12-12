using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;

namespace pro.Controllers
{
    public class extraController : Controller
    {
        dbaseEntities1 db = new dbaseEntities1();
        //
        // GET: /extra/

        public ActionResult Index()
        {
            @ViewBag.data = db.cities.OrderBy(y => y.cityname);
            return View();
        }
        [HttpPost]
        public ActionResult area(int selectedvalue)
        {
            List<string> objcity = new List<string>();
            objcity = db.areas.Where(m => m.cid == selectedvalue).Select(m => m.areaname).ToList();

           // SelectList obgcity = new SelectList(objcity, "id", "areaname", 0);
            return Json(new{Objcity = objcity});
        }
       
        
        

    }
}
