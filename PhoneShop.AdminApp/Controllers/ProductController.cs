using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;
using X.PagedList;

namespace PhoneShop.AdminApp.Controllers
{
    [Authorize(Roles = "admin,manager")]
    public class ProductController : Controller
    {
        private readonly PhoneShopDbContext _context;

        public ProductController(PhoneShopDbContext context)
        {
            _context = context;
        }


        // GET: Product
        public async Task<IActionResult> Index(int? categoryID = null, string? keyword = null, int? page = null)
        {
            var pageNumber = page ?? 1;
            var pageSize = 8;
            ViewBag.PageSize = pageSize;

            var phoneShopDbContext = _context.Products.Include(p => p.Manufacturer).Include(p => p.ProductInCategories).AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                ViewData["Keyword"] = keyword;
                phoneShopDbContext = phoneShopDbContext.Where(e => e.PName.Contains(keyword) || e.PId.ToString().Contains(keyword));
            }

            if (categoryID != null && categoryID != 0)
            {
                ViewData["CategoryID"] = categoryID.ToString();
                var cName = _context.Categories.FirstOrDefault(e => e.CId == categoryID).CName;
                ViewData["CategoryName"] = cName.ToString();
                phoneShopDbContext = phoneShopDbContext.Where(p => p.ProductInCategories.Any(pic => pic.CId == categoryID)).Include(p => p.Manufacturer).AsQueryable();
            }

            return View(await phoneShopDbContext.ToPagedListAsync(pageNumber, pageSize));

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
        [Authorize(Roles = "admin,manager")]

        public async Task<IActionResult> Create([Bind("PId,PName,MId,PDescription,PColor,PStorage,PRam,PScreenSize,PResolution,POperatingSystem,PCamera,PBatteryCapacity,PConnectivity,PWeight,PDimension,PPrice,POriginalPrice,PStock,PAvatar")] 
                                                Product product, IFormFile avatar)
        {
            if (ModelState.IsValid)
            {
                // tải lên các file ảnh khác
                if (avatar != null && avatar.Length > 0)
                {

                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(avatar.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("avatar", "Chỉ cho phép tải lên các tệp hình ảnh định dạng JPG, JPEG, PNG hoặc GIF.");
                        return View(product);
                    }
                    // Get the filename and extension
                    var fileName = Path.GetFileNameWithoutExtension(avatar.FileName);

                    // Create a unique filename
                    var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                    // Create a path for the image file
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "ProductImage", uniqueFileName);

                    // Save the image file to the server
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await avatar.CopyToAsync(stream);
                    }

                    // Set the product avatar property to the filename
                    product.PAvatar = uniqueFileName;
                }


                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MId"] = new SelectList(_context.Manufacturers, "MId", "MAddress", product.MId);
            return View(product);
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
        [Authorize(Roles = "admin,manager")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PName,MId,PDescription,PColor,PStorage,PRam,PScreenSize,PResolution,POperatingSystem,PCamera,PBatteryCapacity,PConnectivity,PWeight,PDimension,PPrice,POriginalPrice,PStock,PAvatar")] Product product, 
                                                IFormFile avatar)
        {
            if (id != product.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the user uploaded a new avatar image
                    if (avatar != null && avatar.Length > 0)
                    {
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extension = Path.GetExtension(avatar.FileName).ToLower();
                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("avatar", "Chỉ cho phép tải lên các tệp hình ảnh định dạng JPG, JPEG, PNG hoặc GIF.");
                            return View(product);
                        }

                        // Get the filename and extension
                        var fileName = Path.GetFileNameWithoutExtension(avatar.FileName);

                        // Create a unique filename
                        var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                        // Create a path for the imagefile
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "ProductImage", uniqueFileName);

                        // Save the image file to the server
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await avatar.CopyToAsync(stream);
                        }

                        // Delete the old avatar image file
                        if (!string.IsNullOrEmpty(product.PAvatar))
                        {
                            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "ProductImage", product.PAvatar);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Set the product avatar property to the new filename
                        product.PAvatar = uniqueFileName;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Products.Any(e => e.PId == id))
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
            ViewData["MId"] = new SelectList(_context.Manufacturers, "MId", "MAddress", product.MId);
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
        [Authorize(Roles = "admin,manager")]

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
