using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pro.Controllers
{
    public class contactController : Controller
    {
        //
        // GET: /contact/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
