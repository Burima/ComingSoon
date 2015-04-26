using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYSComingSoon.BE;

namespace LYSComingSoon.Controllers
{
    public class HomeController : Controller
    {
        User user = new User();
        SendMail sendMail = new SendMail();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendContactUsMail(string first_name, string last_name, string contact_email, string contact_subject, string message)
        {
            user.first_name = first_name;
            user.last_name = last_name;
            user.contact_email = contact_email;
            user.contact_subject = contact_subject;
            user.message = message;

            String ErrorMsg = string.Empty;
            string messagebodyPath = Server.MapPath("~/MailMessageBody.html");
            bool flag = sendMail.SendMailToAdmin(user, out ErrorMsg, messagebodyPath);

            if (flag)
            {
                return Content("Success");
            }
            else
            {
                return Content("Failed");
            }
            
        }

        public ActionResult SendSubscriptionMail(string subscribe_email)
        {

            String ErrorMsg = string.Empty;
            string messagebodyPath = Server.MapPath("~/MailMessageBody.html");
            bool flag = sendMail.SendSubscriptionMail(subscribe_email, out ErrorMsg);

            if (flag)
            {
                return Content("Success");
            }
            else
            {
                return Content("Failed");
            }
        }
    }
}