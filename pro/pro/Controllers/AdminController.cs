using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;
namespace pro.Controllers
{
    //[Authorize("nazim")]
    public class AdminController : Controller
    {
        dbaseEntities1 db = new dbaseEntities1();
        //
        // GET: /Admin/
        
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            ViewBag.user = Session["username"];
            return View();
        }
       
        public ActionResult Ads(string name, int page = 1)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            ViewBag.user = Session["username"];
            if (TempData["msg"] != null)
            {
                string msg = TempData["msg"].ToString();
                ViewBag.msg = msg;
            }
            if (name == "Camera")
            {
                return PartialView(name, db.cameras.OrderByDescending(x => x.id).Where(a => a.status != "post").ToPagedList(page, 5));
            }
            else if (name == "Car")
            {
                return PartialView(name, db.cars.OrderByDescending(x => x.id).ToPagedList(page, 5));
            }
            else if (name == "Mobile")
            {
                return PartialView(name, db.mobiles.OrderByDescending(x => x.id).Where(a => a.status != "post").ToPagedList(page, 5));
            }
            return RedirectToAction("Index");
        }


        public ActionResult Confirmation(string name, int id)
        {
            dbaseEntities1 db1 = new dbaseEntities1();
            if (name == "Camera")
            {
                camera cam = db1.cameras.SingleOrDefault(a => a.id == id);
                cam.status = "post";
                db1.SaveChanges();
                //return RedirectToAction("Ads","Admin",new {name=name});
            }
            return RedirectToAction("Ads", "Admin", new { name = name });
            //return View(name);
        }
    }
}
    


