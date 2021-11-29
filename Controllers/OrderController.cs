using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinalProject.Models;
using FinalProject.Data;

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
