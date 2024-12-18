﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Enums;
using X.PagedList;

namespace PhoneShop.AdminApp.Controllers
{
    [Authorize(Roles = "admin,manager,employee")]
    public class OrderController : Controller
    {
        private readonly PhoneShopDbContext _context;

        public OrderController(PhoneShopDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index(string? keyword, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 8;
            ViewBag.PageSize = pageSize;
            var phoneShopDbContext = _context.Orders.Include(p => p.Customer).ToList();

            if (!string.IsNullOrEmpty(keyword))
            {
                ViewData["Keyword"] = keyword;
                phoneShopDbContext = phoneShopDbContext.Where(e => e.OId.ToString().Contains(keyword)).ToList();
            }

            return View(phoneShopDbContext.ToPagedList(pageNumber, pageSize));
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.OId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            var orderStatus = Enum.GetValues(typeof(OrderStatus));
            ViewData["OStatus"] = new SelectList(orderStatus);
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [Authorize(Roles = "admin,manager,employee")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OId,ODate,CusId,OStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                int lastOrderId = await _context.Orders.MaxAsync(o => o.OId);
                return RedirectToAction("Create", "OrderDetail", new { orderID = lastOrderId });
            }
            var orderStatus = Enum.GetValues(typeof(OrderStatus));
            ViewData["OStatus"] = new SelectList(orderStatus);
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CusId", "CusName");
            var orderStatus = Enum.GetValues(typeof(OrderStatus));
            ViewData["OStatus"] = new SelectList(orderStatus);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin,manager,employee")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OId,ODate,CusId,OStatus")] Order order)
        {
            if (id != order.OId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OId))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CusId", "CusName");
            var orderStatus = Enum.GetValues(typeof(OrderStatus));
            ViewData["OStatus"] = new SelectList(orderStatus);
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin,manager,employee")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'PhoneShopDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.OId == id)).GetValueOrDefault();
        }
    }
}
