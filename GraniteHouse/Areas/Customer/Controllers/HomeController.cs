using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Models;
using GraniteHouse.Data;
using Microsoft.EntityFrameworkCore;
using GraniteHouse.Extensions;

namespace GraniteHouse.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var productsFromDb = await _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).ToListAsync();
            return View(productsFromDb);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.Products.Include(m => m.ProductTypes).
                                        Include(m => m.SpecialTags).Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(product);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsPOST(int id)
        {
            List<int> shoppingCartList = HttpContext.Session.Get<List<int>>("shoppingCartSession");

            if (shoppingCartList == null)
            {
                shoppingCartList = new List<int>();
            }
            shoppingCartList.Add(id);
            HttpContext.Session.Set("shoppingCartSession", shoppingCartList);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

        public IActionResult Remove(int id)
        {
            List<int> shoppingCartList = HttpContext.Session.Get<List<int>>("shoppingCartSession");

            if (shoppingCartList.Count > 0)
            {
                if (shoppingCartList.Contains(id))
                {
                    shoppingCartList.Remove(id);
                }
            }

            HttpContext.Session.Set("shoppingCartSession", shoppingCartList);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
