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
    public class ElectronicsController : Controller
    {
        //
        // GET: /Electronics/
        dbaseEntities1 db = new dbaseEntities1();
        public ActionResult Index()
        {
            List<menu > menus = db.menus.OrderBy(x => x.name).ToList();
            ViewBag.menulist = menus;
            return View(menus);
        }
        public ActionResult Mobile(int page = 1)
        {
            return View(db.mobiles.OrderByDescending(x => x.id).Where(a => a.status == "post").ToPagedList(page, 4));
        }
        public ActionResult Camera(int page=1)
        {
            //db.cameras.ToList();
            return View(db.cameras.OrderByDescending(x => x.id).Where(a=>a.status =="post").ToPagedList(page, 4));
        }

        
    }
}
