using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneShop.AdminApp.ViewModel;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;

namespace PhoneShop.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly PhoneShopDbContext _context;

        public ProductController(PhoneShopDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(int? categoryID, string? keyword)
        {
            var phoneShopDbContext = _context.Products.Include(p => p.Manufacturer);

            if (!string.IsNullOrEmpty(keyword))
            {
                ViewData["Keyword"] = keyword;
                phoneShopDbContext = phoneShopDbContext.Where(e => e.PName.Contains(keyword)).Include(p => p.Manufacturer);
            }
            if (categoryID != null && categoryID != 0)
            {
                ViewData["CategoryID"] = categoryID.ToString();
                var cName = _context.Categories.FirstOrDefault(e => e.CId == categoryID).CName;
                ViewData["CategoryName"] = cName.ToString();
                phoneShopDbContext = phoneShopDbContext.Where(p => p.ProductInCategories.Any(pic => pic.CId == categoryID)).Include(p => p.Manufacturer);
            }

            return View(await phoneShopDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["MId"] = new SelectList(_context.Manufacturers, "MId", "MName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    PName = model.PName,
                    MId = model.MId,
                    PDescription = model.PDescription,
                    PColor = model.PColor,
                    PStorage = model.PStorage,
                    PRam = model.PRam,
                    PScreenSize = model.PScreenSize,
                    PResolution = model.PResolution,
                    POperatingSystem = model.POperatingSystem,
                    PCamera = model.PCamera,
                    PBatteryCapacity = model.PBatteryCapacity,
                    PConnectivity = model.PConnectivity,
                    PWeight = model.PWeight,
                    PDimension = model.PDimension,
                    PPrice = model.PPrice,
                    POriginalPrice = model.POriginalPrice,
                    PStock = model.PStock
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // tải lên các file ảnh khác
                if (model.ImageFiles != null && model.ImageFiles.Count > 0)
                {
                    foreach (var file in model.ImageFiles)
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var uniqueFileName = product.PId.ToString() + "-" + Guid.NewGuid().ToString() + extension;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ProductImage", uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var image = new ProductImage
                        {
                            PIPath = $"/images/{uniqueFileName}",
                            PICaption = "",
                            PIIsDefault = false,
                            PISortOrder = 0
                        };

                        product.ProductImages.Add(image);
                        await _context.SaveChangesAsync();
                    }
                }

                ViewData["MId"] = new SelectList(_context.Manufacturers, "MId", "MAddress", model.MId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["MId"] = new SelectList(_context.Manufacturers, "MId", "MName", product.MId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PName,MId,PDescription,PColor,PStorage,PRam,PScreenSize,PResolution,POperatingSystem,PCamera,PBatteryCapacity,PConnectivity,PWeight,PDimension,PPrice,POriginalPrice,PStock")] Product product)
        {
            if (id != product.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.PId))
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
            ViewData["MId"] = new SelectList(_context.Manufacturers, "MId", "MName", product.MId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'PhoneShopDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}
