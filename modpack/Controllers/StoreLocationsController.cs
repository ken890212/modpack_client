using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using modpack.Models;

namespace modpack.Controllers
{
    public class StoreLocationsController : Controller
    {
        private readonly ModPackContext _context;

        public StoreLocationsController(ModPackContext context)
        {
            _context = context;
        }

        // GET: StoreLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreLocations.ToListAsync());
        }

        // GET: StoreLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = await _context.StoreLocations
                .FirstOrDefaultAsync(m => m.StoreLocationId == id);
            if (storeLocation == null)
            {
                return NotFound();
            }

            return View(storeLocation);
        }

        // GET: StoreLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreLocationId,Name,OfficeTelephone,Address")] StoreLocation storeLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeLocation);
        }

        // GET: StoreLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = await _context.StoreLocations.FindAsync(id);
            if (storeLocation == null)
            {
                return NotFound();
            }
            return View(storeLocation);
        }

        // POST: StoreLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreLocationId,Name,OfficeTelephone,Address")] StoreLocation storeLocation)
        {
            if (id != storeLocation.StoreLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreLocationExists(storeLocation.StoreLocationId))
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
            return View(storeLocation);
        }

        // GET: StoreLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = await _context.StoreLocations
                .FirstOrDefaultAsync(m => m.StoreLocationId == id);
            if (storeLocation == null)
            {
                return NotFound();
            }

            return View(storeLocation);
        }

        // POST: StoreLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeLocation = await _context.StoreLocations.FindAsync(id);
            if (storeLocation != null)
            {
                _context.StoreLocations.Remove(storeLocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreLocationExists(int id)
        {
            return _context.StoreLocations.Any(e => e.StoreLocationId == id);
        }
    }
}
