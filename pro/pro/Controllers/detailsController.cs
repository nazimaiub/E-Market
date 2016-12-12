using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;

namespace pro.Controllers
{
    public class detailsController : Controller
    {
        //
        // GET: /details/
        dbaseEntities1 db = new dbaseEntities1();
        public ActionResult Index(int id)
        {

            return View();
        }

        //
        // GET: /details/Details/5

        public ActionResult CameraDetails(int id=0)
        {
            camera camera = db.cameras.Single(c => c.id == id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
            
        }
        public ActionResult MobileDetails(int id = 0)
        {
            mobile mobile = db.mobiles.Single(c => c.id == id);
            if (mobile == null)
            {
                return HttpNotFound();
            }
            return View(mobile);

        }
        public ActionResult Detailscar1(int id = 0)
        {
            car car = db.cars.Single(c => c.id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);

        }
        

        //
        // GET: /details/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /details/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /details/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /details/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /details/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /details/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
