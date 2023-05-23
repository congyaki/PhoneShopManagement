using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;

namespace PhoneShop.AdminApp.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly PhoneShopDbContext _context;

        public OrderDetailController(PhoneShopDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetail
        public async Task<IActionResult> Index()
        {
            var phoneShopDbContext = _context.TbOrderDetails.Include(o => o.Order).Include(o => o.Product);
            return View(await phoneShopDbContext.ToListAsync());
        }

        // GET: OrderDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbOrderDetails == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.TbOrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetail/Create
        public IActionResult Create()
        {
            ViewData["OId"] = new SelectList(_context.Orders, "OId", "OId");
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PBatteryCapacity");
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,OId,ODQuantity,ODPrice")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OId"] = new SelectList(_context.Orders, "OId", "OId", orderDetail.OId);
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PBatteryCapacity", orderDetail.PId);
            return View(orderDetail);
        }

        // GET: OrderDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbOrderDetails == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.TbOrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OId"] = new SelectList(_context.Orders, "OId", "OId", orderDetail.OId);
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PBatteryCapacity", orderDetail.PId);
            return View(orderDetail);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,OId,ODQuantity,ODPrice")] OrderDetail orderDetail)
        {
            if (id != orderDetail.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.PId))
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
            ViewData["OId"] = new SelectList(_context.Orders, "OId", "OId", orderDetail.OId);
            ViewData["PId"] = new SelectList(_context.Products, "PId", "PBatteryCapacity", orderDetail.PId);
            return View(orderDetail);
        }

        // GET: OrderDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbOrderDetails == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.TbOrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbOrderDetails == null)
            {
                return Problem("Entity set 'PhoneShopDbContext.TbOrderDetails'  is null.");
            }
            var orderDetail = await _context.TbOrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                _context.TbOrderDetails.Remove(orderDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
          return (_context.TbOrderDetails?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}
