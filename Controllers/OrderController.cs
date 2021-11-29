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
       
    }
}
