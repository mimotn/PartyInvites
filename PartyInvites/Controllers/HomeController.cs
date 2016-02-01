using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using PartyInvites.Domain;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(Guest guess)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            SendMail(guess);

            return View("Thanks", guess);
        }

        private void SendMail(Guest guess, bool async = true)
        {
            try
            {
                var body = guess.Name + (guess.WillAttend ? " is attending" : " is not attending");
                var mail = new MailMessage("noreplymvc@gmail.com", guess.Email, "Party invitation", body);
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Timeout = 1000,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("noreplymvc@gmail.com", "yophop2016")
                };

                if (async)
                {
                    Task.Factory.StartNew(() => client.Send(mail)).ContinueWith(o => { ViewBag.Sending = "OK"; });
                }
                else
                {
                    client.Send(mail);
                    ViewBag.Sending = "OK";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Sending = "KO" + ex.Message;
            }
        }
    }
}