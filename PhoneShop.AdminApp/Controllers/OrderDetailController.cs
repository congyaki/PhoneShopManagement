using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;
using PhoneShop.Utilities.Exceptions;

namespace PhoneShop.AdminApp.Controllers
{
    [Authorize(Roles = "admin,manager")]


    public class OrderDetailController : Controller
    {
        private readonly PhoneShopDbContext _context;

        public OrderDetailController(PhoneShopDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetail
        public async Task<IActionResult> Index(int orderID)
        {
            ViewBag.OrderID = orderID;
            var phoneShopDbContext = _context.TbOrderDetails.Where(e => e.OId == orderID).Include(o => o.Product).Include(o => o.Order);
            ViewData["totalOrder"] = phoneShopDbContext.Select(p => p.ODPrice).Sum();
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
        [HttpGet]
        public IActionResult Create(int orderID)
        {
            ViewBag.OrderID = orderID;
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin,manager")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int newOrderID, [Bind("PId,OId,ODQuantity,ODPrice")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                if (_context.TbOrderDetails.Where(e => e.OId == orderDetail.OId).FirstOrDefault(e => e.PId == orderDetail.PId) != null)
                {
                    throw new PhoneShopException("Product đã có trong Order");
                }
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", new {orderID = orderDetail.OId});
            }
            return View("Create", new { orderID = orderDetail.OId });
        }

        [HttpGet]
        public JsonResult GetProductPrice(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                var totalPrice = product.PPrice * quantity;
                var result = new { productName = product.PName, productPrice = product.PPrice, totalPrice = totalPrice };
                return Json(result);
            }

            return Json(null);
        }

        // GET: OrderDetail/Edit/5
        public async Task<IActionResult> Edit(int orderID, int productID)
        {
            if (orderID == null || productID == null || _context.TbOrderDetails == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.TbOrderDetails
                .FirstOrDefaultAsync(m => m.PId == productID && m.OId == orderID);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin,manager")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int orderID, int productID, [Bind("PId,OId,ODQuantity,ODPrice")] OrderDetail orderDetail)
        {
            if (productID != orderDetail.PId || orderID != orderDetail.OId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (_context.TbOrderDetails.Where(e => e.OId == orderID && e.PId == productID) == null)
                {
                    throw new PhoneShopException("Không tìm thấy sản phẩm trong order");
                }
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
                return RedirectToAction(nameof(Index), new { orderID = orderID });
            }
            return View(orderDetail);
        }

        // GET: OrderDetail/Delete/5
        public async Task<IActionResult> Delete(int orderID, int productID)
        {
            if (orderID == null || productID == null || _context.TbOrderDetails == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.TbOrderDetails
                .FirstOrDefaultAsync(m => m.PId == productID && m.OId == orderID);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin,manager")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int orderID, int productID)
        {
            if (_context.TbOrderDetails == null)
            {
                return Problem("Entity set 'PhoneShopDbContext.TbOrderDetails'  is null.");
            }
            var orderDetail = await _context.TbOrderDetails.FirstOrDefaultAsync(m => m.PId == productID && m.OId == orderID);
            if (orderDetail != null)
            {
                _context.TbOrderDetails.Remove(orderDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {orderID = orderID});
        }

        private bool OrderDetailExists(int id)
        {
          return (_context.TbOrderDetails?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}
