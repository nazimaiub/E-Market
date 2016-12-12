using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;
namespace pro.Controllers
{
    public class JobServiceController : Controller
    {
        //
        // GET: /Job Service/
        dbaseEntities1 db = new dbaseEntities1();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Job()
        {
            List<job> jobs = db.jobs.ToList();
            return View(jobs);
        }

    }
}
