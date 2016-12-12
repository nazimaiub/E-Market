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
    
    public class LoginController : Controller
    {
        dbaseEntities1 db = new dbaseEntities1();
        
        //
        // GET: /Login/

       
        public ActionResult Index()
        {
            
            return View();
        }
        
        public ActionResult addmenu()
        {
            @ViewBag.data = db.menus.OrderBy(y => y.name).Where(x => x.parentid == 0);

            return View();
        }

        public ActionResult admin1()
        {

            return View();
        }
        public ActionResult createmenu(menu menu,int category)
        {

            //com.poston = DateTime.Now;
            //com.status = "post";
            //land.image = ;
            menu.navurl = menu.name;
            menu.parentid = category;

            db.menus.AddObject(menu);
            db.SaveChanges();
            @ViewBag.msg = "Menu Has Been Added";
            return View("addmenu");
        }
        [HttpPost]
        public ActionResult verify(FormCollection form)
        {
                var un = form["username"];
                var pass = form["password"];
                var count = db.contactinfoes.Where(x => x.name == un && x.password == pass).FirstOrDefault(); 
                if (count != null)
                {
                    FormsAuthentication.SetAuthCookie(un, true);
                    Session["username"]=un;
                    return RedirectToAction("Index","Admin");
                }
            


            ViewBag.s = "Incorrect Name or Password";
           
                return View("Index");
        }
        public ActionResult logout()
        {
            Session.Clear();
            return View("Index");
        }

            
        }
    }

