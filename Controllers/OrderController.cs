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
            return View(list);
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
            order.Price = record.Price;
            order.Quantity = record.Quantity;
            order.Address = record.Address;
            order.ContactNum = record.ContactNum;
            order.DateAdded = DateTime.Now;
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
        public IActionResult Track()
        {
            return View();
        }
    }
}
