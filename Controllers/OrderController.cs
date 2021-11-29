using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinalProject.Models;
using FinalProject.Data;
using System.Net.Mail;

namespace FinalProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Orders.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Order record)
        {
            var order = new Order();
            order.ProductName = record.ProductName;
            order.Quantity = record.Quantity;
            order.Address = record.Address;
            order.ContactNum = record.ContactNum;
            order.ModeOfPayment = record.ModeOfPayment;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
       
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var order = _context.Orders.Where(i => i.OrderID == id).SingleOrDefault();
            if (order == null)
            {
                return RedirectToAction("Index");
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Confirmation(Order confirmation)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("istoreonlineshoppingplatform@gmail.com", "iStore")
            };

            mail.To.Add(new MailAddress(confirmation.Email));
            mail.Subject = "Inquiry From" + confirmation.Sender + " (" + confirmation.Subject + ")";

            string message = "Hey! " + record.Sender + "<br/>" + "Thanks for reaching out! " +
                "We have received your concern regarding " + record.Subject + ". Kindly wait for 12-24hrs for our response." +
                "We'll get back to you as soon as possible. Thank you!";
            mail.Body = message;
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
        }


}
}
