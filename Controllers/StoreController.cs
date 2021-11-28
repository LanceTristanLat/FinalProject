using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinalProject.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly ApplicationDbContext _context;

        public StoreController(ILogger<StoreController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Items.ToList();
            if (Request.Query.ContainsKey("card"))
            {
                products = products.Where(p => p.CatID ==
                int.Parse(Request.Query["card"].ToString()))
                .ToList();
            }
            var record = new StoreViewModel()
            {
                ProductList = products
            };
            return View(record);
        }
        public IActionResult Earphones()
        {
            var products = _context.Items.Where(i => i.Categories == Categories.Earphones).ToList();
            var record = new StoreViewModel()
            {
                ProductList = products
            };
            return View(record);
        }
        public IActionResult Macbook()
        {
            var products = _context.Items.Where(i => i.Categories == Categories.Macbooks).ToList();
            var record = new StoreViewModel()
            {
                ProductList = products
            };
            return View(record);
        }
        public IActionResult Iphones()
        {
            var products = _context.Items.Where(i => i.Categories == Categories.Iphones).ToList();
            var record = new StoreViewModel()
            {
                ProductList = products
            };
            return View(record);
        }
        public IActionResult Watch()
        {
            var products = _context.Items.Where(i => i.Categories == Categories.AppleWatch).ToList();
            var record = new StoreViewModel()
            {
                ProductList = products
            };
            return View(record);
        }
    }
}
