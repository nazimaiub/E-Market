using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;
using System.IO;

namespace pro.Controllers
{
    public class AddfreepostController : Controller
    {
      
        dbaseEntities1 db = new dbaseEntities1();
        //
        // GET: /Addfreepost/
        
         public ActionResult Index()
        {
            @ViewBag.data = db.menus.OrderBy(y => y.name).Where(x => x.parentid != 0);
           
            return View();
        }
   
    [HttpPost]
        public ActionResult Create(car car,HttpPostedFileBase file,int ddlstate,string area)
        {
        if (file.ContentLength > 0)
    {
        var fileName = Path.GetFileName(file.FileName);
        var path = Path.Combine(Server.MapPath("~/photo"), fileName);
        file.SaveAs(path);
        car.image = "~/photo/" + file.FileName;
        ViewBag.msg = "Your Add has been Posted";
    }  
            car.poston = DateTime.Now;
            car.status = "post";
            //car.cityid = ddlstate;
            car.area = area;
           
            db.cars.AddObject(car);
            db.SaveChanges();

            return View("Index");
        }
    [HttpPost]
    public ActionResult Createcamera(camera camera, HttpPostedFileBase file)
    {
        if (ModelState.IsValid)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/photo"), fileName);
                file.SaveAs(path);
                camera.image = "~/photo/" + file.FileName;

            }
            camera.posttime = DateTime.Now;
            camera.status = "pending";



            db.cameras.AddObject(camera);
            db.SaveChanges();
            @ViewBag.msg = "Your Add has been Posted For Review";
            return View("Index");
            
        }
        return View("Createcamera", "_layout", camera);
        
    }
    [HttpPost]
    public ActionResult Createmobile(mobile mobile, HttpPostedFileBase file)
    {
        if (file.ContentLength > 0)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/photo"), fileName);
            file.SaveAs(path);
            mobile.image = "~/photo/" + file.FileName;
        }
        mobile.poston = DateTime.Now.ToString();
        mobile.status = "pending";

        db.mobiles.AddObject(mobile);
        db.SaveChanges();
        @ViewBag.msg = "Your Add has been Sent To Admin Panel For Review";
        return View("Index");
    }
        public ActionResult createland(land land)
        {
            
            land.poston = DateTime.Now;
            land.status = "post";
            //land.image = ;
            db.lands.AddObject(land);
            db.SaveChanges();
            @ViewBag.msg = "Your Add has been Posted";
            return View("Index");
        }
        
        public ActionResult createfurniture(furniture fur)
        {
           
            fur.poston = DateTime.Now;
            fur.status = "post";
            //land.image = ;
            db.furnitures.AddObject(fur);
            db.SaveChanges();
            @ViewBag.msg = "Your Add has been Posted";
            return View("Index");
        }
        //[HttpGet]
       // [ActionName("Category")]
        public ActionResult Categorydetails(string name)
        {
            @ViewBag.msg = "";
            System.Threading.Thread.Sleep(2000);
            return PartialView(name);
           
        }
       
    }
}

            
            
           
        
       
    

