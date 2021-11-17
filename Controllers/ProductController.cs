using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinalProject.Models;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;


namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Items.Include(p => p.Categories).ToString();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item record)
        {
            var selectedCategory = _context.Categories.Where(c => c.CatId == record.ProductID).SingleOrDefault();
            
            var product = new Item();
            product.ProductName = record.ProductName;
            product.ProductCode = record.ProductCode;
            product.ProductDescription = record.ProductDescription;
            product.ProductPrice = record.ProductPrice;
            product.Available = 0;
            product.DateAdded = DateTime.Now;
            product.Categories = selectedCategory;

            _context.Items.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            
            var product = _context.Items.Where(p => p.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Item record)
        {
            var product = _context.Items.Where(p => p.ProductID == id).SingleOrDefault();

            var selectedCategory = _context.Categories.Where(c => c.CatId == record.CatId).SingleOrDefault();

            product.ProductName = record.ProductName;
            product.ProductCode = record.ProductCode;
            product.ProductDescription = record.ProductDescription;
            product.ProductPrice = record.ProductPrice;
            product.Available = 0;
            product.DateAdded = DateTime.Now;
            product.Categories = selectedCategory;


            _context.Items.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Items.Where(p => p.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            _context.Items.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
