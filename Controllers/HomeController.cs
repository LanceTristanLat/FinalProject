using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;


namespace FinalProject.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user =  _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if(user.Type == UserTypes.Admin)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(Contact record)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("istoreonlineshoppingplatform@gmail.com", "Administrator")
            };

            mail.To.Add(new MailAddress(record.Email));
            mail.Subject = "Inquiry From" + record.Sender + " (" + record.Subject + ")";

            string message = "Hey! " + record.Sender + "<br/>" + "Thanks for reaching out! " +
                "We have received your concern regarding " + record.Subject + ". Kindly wait for 12-24hrs for our response." +
                "We'll get back to you as soon as possible. Thank you!";
            mail.Body = record.Message;
            mail.IsBodyHtml = true;

            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("istoreonlineshoppingplatform@gmail.com", "Entprog2021"),
                EnableSsl = true
            };
            smtp.Send(mail);
            ViewBag.Message = "Inquiry sent.";
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
