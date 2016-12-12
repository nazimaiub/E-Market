using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pro.Models;
using System.Text;
//using System.Web.Mail;
using System.Net.Mail;
using System.Net;
//using System.Net.Mail;
namespace pro.Controllers
{
    public class ViewDetailsController : Controller
    {
        //
        // GET: /ViewDetails/

        public ActionResult Index(string name, int id)
        {
            if(Session["username"]==null)
            {
                return RedirectToAction("Index", "login");
            }
            @ViewBag.user = Session["username"];
            //if (TempData["msg"] != null)
            //{
            //    string msg=TempData["msg"].ToString();
            //    ViewBag.msg = msg; 
            //}
            dbaseEntities1 db = new dbaseEntities1();
            if (name == "Camera")
            {
                return PartialView(name, db.cameras.Single(c => c.id == id));
            }
            if (name == "Mobile")
            {
                return PartialView(name, db.mobiles.Single(c => c.id == id));
            }

           
            return View();
        }
        [HttpPost]
        public ActionResult succcessmail(FormCollection fc)
        {
            int id=Convert.ToInt32(fc["modelid"]);
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear Sir,<br/><br/>");
            sb.Append("Your Add Has SuccessFully Been Posted At Our WebSite.You can Watch Your Add By Clicking The Following Link Given");
            sb.Append("<br/>");
            sb.Append("http://localhost:4077/details/CameraDetails/" + fc["modelid"].ToString());
            sb.Append("<br/><br/>");
            sb.Append("<b>Sell Me</b>");
            var server = new SmtpClient();
            server.Host = "smtp.gmail.com";
            server.Port = 587;
            server.UseDefaultCredentials = false;
            server.Credentials = new System.Net.NetworkCredential("thirdnazim@gmail.com", "daimond1");
            server.EnableSsl = true;
            var email = new MailMessage();
            MailAddress me = new MailAddress("doublenazim@gmail.com");
            email.From = me;
            email.To.Add(fc["rmail"].ToString());
            email.Subject = fc["subject"].ToString();
            email.Body =sb.ToString() ;
            email.IsBodyHtml = true;
            try
            {
                server.Send(email);
            }
            catch (SmtpFailedRecipientException error)
            {
                //MessageBox.Show("error: " + error.Message + "\nFailing recipient: " + error.FailedRecipient);
            }
            ViewBag.msg = "message sent";
            dbaseEntities1 db = new dbaseEntities1();
            camera c = db.cameras.SingleOrDefault(a => a.id ==id);
            c.status = "post";
            c.posttime = System.DateTime.Now;
            db.SaveChanges();
            TempData["msg"] = "Add And Email Has SuccessFully Been Posted";
            return RedirectToAction("Ads", "Admin", new {name="Camera" });


            return View();
        }
        public ActionResult unsucccessmail(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["modelid"]);
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear Sir,<br/><br/>");
            sb.Append("Your Add Has SuccessFully Been Deleted From Our WebSite From Our Terms & ConDition.You can Check our Add Policy By Clicking The Following Link Given");
            //sb.Append("<br/>");
            //sb.Append("http://localhost:4077/details/CameraDetails/" + fc["modelid"].ToString());
            sb.Append("<br/><br/>");
            sb.Append("<b>Sell Me</b>");
            var server = new SmtpClient();
            server.Host = "smtp.gmail.com";
            server.Port = 587;
            server.UseDefaultCredentials = false;
            server.Credentials = new System.Net.NetworkCredential("thirdnazim@gmail.com", "daimond1");
            server.EnableSsl = true;
            var email = new MailMessage();
            MailAddress me = new MailAddress("doublenazim@gmail.com","AdminSellMe");
            email.From = me;
            email.To.Add(fc["rmail"].ToString());
            email.Subject = fc["subject"].ToString();
            email.Body = sb.ToString();
            email.IsBodyHtml = true;
            try
            {
                server.Send(email);
            }
            catch (SmtpFailedRecipientException error)
            {
                //MessageBox.Show("error: " + error.Message + "\nFailing recipient: " + error.FailedRecipient);
            }
            ViewBag.msg = "message sent";
            dbaseEntities1 db = new dbaseEntities1();
            camera c = db.cameras.SingleOrDefault(a => a.id == id);
            db.cameras.DeleteObject(c);
            //c.status = "post";
           // c.posttime = System.DateTime.Now;
            db.SaveChanges();
            TempData["msg"] = "Add Deleted And Email Sent";
            return RedirectToAction("Ads", "Admin", new { name = "Camera" });


            return View();
        }
        [HttpPost]
        public ActionResult MobileSucccessmail(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["modelid"]);
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear Sir,<br/><br/>");
            sb.Append("Your Add Has SuccessFully Been Posted At Our WebSite.You can Watch Your Add By Clicking The Following Link Given");
            sb.Append("<br/>");
            sb.Append("http://localhost:4077/details/MobileDetails/" + fc["modelid"].ToString());
            sb.Append("<br/><br/>");
            sb.Append("<b>Sell Me</b>");
            var server = new SmtpClient();
            server.Host = "smtp.gmail.com";
            server.Port = 587;
            server.UseDefaultCredentials = false;
            server.Credentials = new System.Net.NetworkCredential("doublenazim@gmail.com", "city.nazim20");
            server.EnableSsl = true;
            var email = new MailMessage();
            MailAddress me = new MailAddress("doublenazim@gmail.com");
            email.From = me;
            email.To.Add(fc["rmail"].ToString());
            email.Subject = fc["subject"].ToString();
            email.Body = sb.ToString();
            email.IsBodyHtml = true;
            try
            {
                server.Send(email);
            }
            catch (SmtpFailedRecipientException error)
            {
                //MessageBox.Show("error: " + error.Message + "\nFailing recipient: " + error.FailedRecipient);
            }
            ViewBag.msg = "message sent";
            dbaseEntities1 db = new dbaseEntities1();
            mobile m = db.mobiles.SingleOrDefault(a => a.id == id);
            m.status = "post";
            m.poston = System.DateTime.Now.ToString();
            db.SaveChanges();
            TempData["msg"] = "Add And Email Has SuccessFully Been Posted";
            return RedirectToAction("Ads", "Admin", new { name = "Mobile" });


            return View();
        }
        public ActionResult MobileUnsucccessmail(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["modelid"]);
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear Sir,<br/><br/>");
            sb.Append("Your Add Has SuccessFully Been Deleted From Our WebSite From Our Terms & ConDition.You can Check our Add Policy By Clicking The Following Link Given");
            //sb.Append("<br/>");
            //sb.Append("http://localhost:4077/details/MobileDetails/" + fc["modelid"].ToString());
            sb.Append("<br/><br/>");
            sb.Append("<b>Sell Me</b>");
            var server = new SmtpClient();
            server.Host = "smtp.gmail.com";
            server.Port = 587;
            server.UseDefaultCredentials = false;
            server.Credentials = new System.Net.NetworkCredential("thirdnazim@gmail.com", "daimond1");
            server.EnableSsl = true;
            var email = new MailMessage();
            MailAddress me = new MailAddress("doublenazim@gmail.com", "AdminSellMe");
            email.From = me;
            email.To.Add(fc["rmail"].ToString());
            email.Subject = fc["subject"].ToString();
            email.Body = sb.ToString();
            email.IsBodyHtml = true;
            try
            {
                server.Send(email);
            }
            catch (SmtpFailedRecipientException error)
            {
                //MessageBox.Show("error: " + error.Message + "\nFailing recipient: " + error.FailedRecipient);
            }
            ViewBag.msg = "message sent";
            dbaseEntities1 db = new dbaseEntities1();
            mobile m = db.mobiles.SingleOrDefault(a => a.id == id);
            db.mobiles.DeleteObject(m);
            db.SaveChanges();
            TempData["msg"] = "Add Deleted And Email Sent";
            return RedirectToAction("Ads", "Admin", new { name = "Mobile" });


            return View();
        }
    }
}
