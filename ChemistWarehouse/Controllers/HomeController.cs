using ChemistWarehouse.Data;
using ChemistWarehouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChemistWarehouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductInfos.ToListAsync());
        }

        public async Task<IActionResult> ViewProductByCategory(int? id)
        {
            var category = await _context.Categories.FindAsync(id);
            ViewData["CategoryName"] = "None";
            if (category != null)
            {
                ViewData["CategoryName"] = category.CategoryName;
            }
            var applicationDbContext = _context.ProductInfos
                .Include(j => j.Category)
                .Where(m => m.CategoryID == id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemInfo = await _context.ProductInfos
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (itemInfo == null)
            {
                return NotFound();
            }

            return View(itemInfo);
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos.FindAsync(id);
            if (productInfo == null)
            {
                return NotFound();
            }
            string userid = _userManager.GetUserName(this.User);
            var carts = _context.Carts
                .Include(m => m.CartItems)
                .Where(m => m.UserID == userid && m.CartStatus.Equals("Cart")).FirstOrDefault();
            if (carts != null)
            {
                CartItem cartitem = null;
                foreach (CartItem item in carts.CartItems)
                {
                    if (item.ProductID == productInfo.ProductID)
                    {
                        cartitem = item;
                        break;
                    }
                }
                if (cartitem != null)
                {
                    cartitem.Quantity += 1;
                    _context.Update(cartitem);
                }
                else
                {
                    CartItem item = new CartItem();
                    item.CartID = carts.CartID;
                    item.ProductID = productInfo.ProductID;
                    item.Price = productInfo.SalePrice;
                    item.Quantity = 1;
                    item.Total = item.Price * item.Quantity;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                Cart cart = new Cart();
                cart.UserID = userid;
                cart.CartDate = DateTime.Now;
                cart.Address = "";
                cart.ContactNo = "";
                cart.OrderDate = DateTime.Now;
                cart.CartStatus = "Cart";
                _context.Add(cart);
                await _context.SaveChangesAsync();
                CartItem item = new CartItem();
                item.CartID = cart.CartID;
                item.ProductID = productInfo.ProductID;
                item.Price = productInfo.SalePrice;
                item.Quantity = 1;
                item.Total = item.Price * item.Quantity;
                _context.Add(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MyCart));
        }

        [Authorize]
        public async Task<IActionResult> DeleteCartItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyCart));
        }

        [Authorize]
        public async Task<IActionResult> MyCart()
        {
            string userid = _userManager.GetUserName(this.User);
            var cart = await _context.Carts
                .Include(m => m.CartItems)
                .Where(m => m.UserID == userid && m.CartStatus.Equals("Cart")).FirstOrDefaultAsync();
            if (cart != null)
            {
                int quantity = 0;
                float total = 0.0F;
                foreach (CartItem item in cart.CartItems)
                {
                    item.ProductInfo = await _context.ProductInfos.Where(m => m.ProductID == item.ProductID).FirstOrDefaultAsync();
                    quantity += item.Quantity;
                    total += item.Total;
                }
                ViewData["Total"] = total;
                ViewData["Quantity"] = quantity;
            }
            return View(cart);
        }

        [Authorize]
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(m => m.CartItems)
                .FirstOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }
            else if (cart.CartItems.Count == 0)
            {
                return NotFound();
            }
            int quantity = 0;
            float total = 0.0F;
            foreach (CartItem item in cart.CartItems)
            {
                item.ProductInfo = await _context.ProductInfos.Where(m => m.ProductID == item.ProductID).FirstOrDefaultAsync();
                quantity += item.Quantity;
                total += item.Total;
            }
            ViewData["Total"] = total;
            ViewData["Quantity"] = quantity;
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(int id, [Bind("CartID,UserID,CartDate,CartStatus,OrderDate,Address,ContactNo")] Cart cartInfo)
        {
            if (id != cartInfo.CartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cartInfo.CartStatus = "Order";
                    cartInfo.OrderDate = DateTime.Now;
                    _context.Update(cartInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return RedirectToAction(nameof(MyOrders));
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            string userid = _userManager.GetUserName(this.User);
            var carts = _context.Carts
                .Include(m => m.CartItems)
                .Where(m => m.UserID == userid && !m.CartStatus.Equals("Cart"));
            return View(await carts.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> OrderDetails(int? id)
        {
            var cart = await _context.Carts
                .Include(m => m.CartItems)
                .Where(m => m.CartID == id).FirstOrDefaultAsync();
            if (cart != null)
            {
                int quantity = 0;
                float total = 0.0F;
                foreach (CartItem item in cart.CartItems)
                {
                    item.ProductInfo = await _context.ProductInfos.Where(m => m.ProductID == item.ProductID).FirstOrDefaultAsync();
                    quantity += item.Quantity;
                    total += item.Total;
                }
                ViewData["Total"] = total;
                ViewData["Quantity"] = quantity;
            }
            return View(cart);
        }

        [Authorize]
        public async Task<IActionResult> CancelOrder(int? id)
        {
            var cart = await _context.Carts
                .Include(m => m.CartItems)
                .Where(m => m.CartID == id).FirstOrDefaultAsync();
            if (cart != null)
            {
                cart.CartStatus = "Cancel";
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MyOrders));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
