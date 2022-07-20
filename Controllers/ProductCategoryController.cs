﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCuisine.DataBase;
using NetCuisine.Models;

namespace NetCuisine.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductCategoryModels
        public async Task<IActionResult> Index()
        {
           var test= await _context.ProductCategory.ToListAsync();
            return View(test);
        }

        // GET: ProductCategoryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryModel = await _context.ProductCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategoryModel == null)
            {
                return NotFound();
            }

            return View(productCategoryModel);
        }

        // GET: ProductCategoryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategoryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Picture")] ProductCategoryModel productCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCategoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCategoryModel);
        }

        // GET: ProductCategoryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryModel = await _context.ProductCategory.FindAsync(id);
            if (productCategoryModel == null)
            {
                return NotFound();
            }
            return View(productCategoryModel);
        }

        // POST: ProductCategoryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Picture")] ProductCategoryModel productCategoryModel)
        {
            if (id != productCategoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryModelExists(productCategoryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productCategoryModel);
        }

        // GET: ProductCategoryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryModel = await _context.ProductCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategoryModel == null)
            {
                return NotFound();
            }

            return View(productCategoryModel);
        }

        // POST: ProductCategoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCategoryModel = await _context.ProductCategory.FindAsync(id);
            _context.ProductCategory.Remove(productCategoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryModelExists(int id)
        {
            return _context.ProductCategory.Any(e => e.Id == id);
        }
    }
}
