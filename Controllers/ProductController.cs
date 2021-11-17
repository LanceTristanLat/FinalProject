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
            var list = _context.Products.Include(p => p.Category).ToString();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product record)
        {
            var selectedCategory = _context.Categories.Where(c => c.CatId == record.CatId).SingleOrDefault();
            
            var product = new Product();
            product.Name = record.Name;
            product.Code = record.Code;
            product.Description = record.Description;
            product.Price = record.Price;
            product.Available = 0;
            product.DateAdded = DateTime.Now;
            product.Status = "Active";
            product.Category = selectedCategory;
            product.CatId = record.CatId;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            
            var product = _context.Products.Where(p => p.ProductId == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Product record)
        {
            var product = _context.Products.Where(p => p.ProductId == id).SingleOrDefault();

            var selectedCategory = _context.Categories.Where(c => c.CatId == record.CatId).SingleOrDefault();

            var product = new Product();
            product.Name = record.Name;
            product.Code = record.Code;
            product.Description = record.Description;
            product.Price = record.Price;
            product.Available = 0;
            product.DateAdded = DateTime.Now;
            product.Status = "Active";
            product.Category = selectedCategory;
            product.CatId = record.CatId;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Products.Where(p => p.ProductId == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
