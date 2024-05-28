using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;

namespace PhoneShop.AdminApp.Controllers
{
    [Authorize(Roles = "Admin,Manager")]

    public class ProductInCategoryController : Controller
    {
        private readonly PhoneShopDbContext _context;

        public ProductInCategoryController(PhoneShopDbContext context)
        {
            _context = context;
        }

        // GET: ProductInCategory
        public async Task<IActionResult> Index()
        {
            var phoneShopDbContext = _context.ProductInCategories.Include(p => p.Category).Include(p => p.Product);
            return View(await phoneShopDbContext.ToListAsync());
        }

        // GET: ProductInCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductInCategories == null)
            {
                return NotFound();
            }

            var productInCategory = await _context.ProductInCategories
                .Include(p => p.Category)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.CId == id);
            if (productInCategory == null)
            {
                return NotFound();
            }

            return View(productInCategory);
        }

        [HttpGet]
        public JsonResult GetDisplay(int productId, int categoryId)
        {
            var product = _context.Products.Find(productId);
            var category = _context.Categories.Find(categoryId);


            if (product != null && category != null)
            {
                var result = new { productName = product.PName, categoryName = category.CName };
                return Json(result);
            }

            return Json(null);
        }

        // GET: ProductInCategory/Create
        public IActionResult Create()
        {
            ViewData["CId"] = new SelectList(_context.Categories, "CId", "CName");
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PName");
            return View();
        }

        // POST: ProductInCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,CId")] ProductInCategory productInCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CId"] = new SelectList(_context.Categories, "CId", "CName", productInCategory.CId);
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PBatteryCapacity", productInCategory.PId);
            return View(productInCategory);
        }

        // GET: ProductInCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductInCategories == null)
            {
                return NotFound();
            }

            var productInCategory = await _context.ProductInCategories.FindAsync(id);
            if (productInCategory == null)
            {
                return NotFound();
            }
            ViewData["CId"] = new SelectList(_context.Categories, "CId", "CName", productInCategory.CId);
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PBatteryCapacity", productInCategory.PId);
            return View(productInCategory);
        }

        // POST: ProductInCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,CId")] ProductInCategory productInCategory)
        {
            if (id != productInCategory.CId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInCategoryExists(productInCategory.CId))
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
            ViewData["CId"] = new SelectList(_context.Categories, "CId", "CName", productInCategory.CId);
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PBatteryCapacity", productInCategory.PId);
            return View(productInCategory);
        }

        // GET: ProductInCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductInCategories == null)
            {
                return NotFound();
            }

            var productInCategory = await _context.ProductInCategories
                .Include(p => p.Category)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.CId == id);
            if (productInCategory == null)
            {
                return NotFound();
            }

            return View(productInCategory);
        }

        // POST: ProductInCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductInCategories == null)
            {
                return Problem("Entity set 'PhoneShopDbContext.ProductInCategories'  is null.");
            }
            var productInCategory = await _context.ProductInCategories.FindAsync(id);
            if (productInCategory != null)
            {
                _context.ProductInCategories.Remove(productInCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInCategoryExists(int id)
        {
          return (_context.ProductInCategories?.Any(e => e.CId == id)).GetValueOrDefault();
        }
    }
}
