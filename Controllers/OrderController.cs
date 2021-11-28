using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            //var list = _context.Orders.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Create(Order record)
        //{
        //    var order = new Order();
        //    order.ProductName = record.ProductName;
        //    order.Quantity = record.Quatity;
        //    order.Address = record.Address;
        //    order.ContactNum = record.ContactNum;
        //    order.ModeOfDelivery = record.ModeOfDelivery;

        //    _context.Orders.Add(order);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public IActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var product = _context.Items.Where(p => p.OrderID == id).SingleOrDefault();
        //    if (product == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}
        [HttpPost]
        //public IActionResult Edit(int? id, Order record)
        //{
        //    var order = _context.Orders.Where(i => i.OrderID == id).SingleOrDefault();
        //    var order = new Order();
        //    order.ProductName = record.ProductName;
        //    order.Quantity = record.Quatity;
        //    order.Address = record.Address;
        //    order.ContactNum = record.ContactNum;
        //    order.ModeOfDelivery = record.ModeOfDelivery;

        //    _context.Orders.Update(order);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var order = _context.Orders.Where(i => i.OrderID == id).SingleOrDefault();
        //    if (order == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    _context.Orders.Remove(order);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public IActionResult Receipt()
        //{
        //    var list = _context.Orders.ToList();
        //    return View(list);
        //}
    }
}
