using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using Microsoft.AspNetCore.Mvc;


namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecapController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RecapController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET Index Action Method
        public IActionResult Index()
        {
            return View(_db.Recap.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View(_db.Recap.ToList());
        }

        //POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recap recap)
        {
            if (ModelState.IsValid)
            {
                _db.Recap.Add(recap);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(recap);
        }

        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recap = await _db.Recap.FindAsync(id);
            if (recap == null)
            {
                return NotFound();
            }
            return View(recap);
        }

        //POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recap recap)
        {
            if (id != recap.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Recap.Update(recap);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(recap);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recap = await _db.Recap.FindAsync(id);
            if (recap == null)
            {
                return NotFound();
            }
            return View(recap);
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recap = await _db.Recap.FindAsync(id);
            if (recap == null)
            {
                return NotFound();
            }
            return View(recap);
        }

        //POST Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Recap recap)
        {
            if (id != recap.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Recap.Remove(recap);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(recap);
        }
    }
}