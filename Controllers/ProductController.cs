using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinalProject.Models;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;


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
        public IActionResult Create(Item record, IFormFile ImagePath)
        {
            var selectedCategory = _context.Items.Where(c => c.CatID == record.ProductID).SingleOrDefault();
            
            var product = new Item();
            product.ProductName = record.ProductName;
            product.ProductCode = record.ProductCode;
            product.ProductDescription = record.ProductDescription;
            product.ProductPrice = record.ProductPrice;
            product.Available = 0;
            product.DateAdded = DateTime.Now;
            product.Categories = selectedCategory;

            if (ImagePath != null)
            {
                if (ImagePath.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/images/products", ImagePath.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImagePath.CopyTo(stream);
                    }
                    product.ImagePath = ImagePath.FileName;
                }
            }
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

            var selectedCategory = _context.Items.Where(c => c.CatID == record.CatID).SingleOrDefault();

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
