using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ContactForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public void SendMail(string fullName, string email, string phoneNumber, string companyName, string title, string message)
        {
            SmtpClient client = ConfigureSmtpClient();
            MailMessage mail = new MailMessage(email, "miskens@hotmail.com");
            mail.Subject = title;
            mail.IsBodyHtml = false;
            message = AppendMessage(fullName, phoneNumber, companyName, message);

            mail.Body = message;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public static SmtpClient ConfigureSmtpClient()
        {
            SmtpClient client = new SmtpClient();

            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("support", "support$");
            client.Host = "mgms.imagemediagate.com";

            return client;
        }

        public string AppendMessage(string fullName, string phoneNumber, string companyName, string message)
        {
            message += Environment.NewLine + Environment.NewLine + "Mvh" +
            Environment.NewLine + fullName +
            Environment.NewLine + phoneNumber +
            Environment.NewLine + companyName;

            return message;
        }
    }
}