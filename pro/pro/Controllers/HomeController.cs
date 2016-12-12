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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        dbaseEntities1 db = new dbaseEntities1();
        

        public ActionResult Index(int page=1)
        {
           //List<menu> menus = db.menus.OrderBy(x=>x.name).ToList();
            //var res=db.cities.GroupJoin(db.areas,a=>a.id,b=>b.cid,
          // ViewBag.menulist = menus;
            List<Allproducts> lproduct = new List<Allproducts>();
            var camera = db.cameras.Where(x=>x.status=="post").OrderBy(x => x.brandname);
            foreach(var item in camera)
            {
                Allproducts products = new Allproducts();
                products.proid = item.id;
                products.proname = item.brandname;
                products.time = item.posttime;
                products.price = item.price;
                products.city = item.location;
                products.image = item.image;
                products.category = "Camera";
                lproduct.Add(products);
            }
            
            
            lproduct = lproduct.OrderByDescending(x => x.time).ToList();
            //ViewBag.products = sort;

           return View(lproduct.ToPagedList(page, 4));
        }
        public ActionResult detail()
        {
            
            return View();
        }
        public ViewResult layout()
        {

            return View();
        }
    }
}
