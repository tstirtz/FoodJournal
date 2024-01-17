using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodJournalWebApp.Data;
using FoodJournalWebApp.Models;

namespace FoodJournalWebApp.Controllers
{
    public class WellnessChecksController : Controller
    {
        private readonly FoodJournalWebAppContext _context;

        public WellnessChecksController(FoodJournalWebAppContext context)
        {
            _context = context;
        }

        // GET: WellnessChecks
        public async Task<IActionResult> Index()
        {
              return _context.WellnessCheck != null ? 
                          View(await _context.WellnessCheck.ToListAsync()) :
                          Problem("Entity set 'FoodJournalWebAppContext.WellnessCheck'  is null.");
        }

        // GET: WellnessChecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WellnessCheck == null)
            {
                return NotFound();
            }

            var wellnessCheck = await _context.WellnessCheck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wellnessCheck == null)
            {
                return NotFound();
            }

            return View(wellnessCheck);
        }

        // GET: WellnessChecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WellnessChecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time")] WellnessCheck wellnessCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wellnessCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wellnessCheck);
        }

        // GET: WellnessChecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WellnessCheck == null)
            {
                return NotFound();
            }

            var wellnessCheck = await _context.WellnessCheck.FindAsync(id);
            if (wellnessCheck == null)
            {
                return NotFound();
            }
            return View(wellnessCheck);
        }

        // POST: WellnessChecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time")] WellnessCheck wellnessCheck)
        {
            if (id != wellnessCheck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wellnessCheck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WellnessCheckExists(wellnessCheck.Id))
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
            return View(wellnessCheck);
        }

        // GET: WellnessChecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WellnessCheck == null)
            {
                return NotFound();
            }

            var wellnessCheck = await _context.WellnessCheck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wellnessCheck == null)
            {
                return NotFound();
            }

            return View(wellnessCheck);
        }

        // POST: WellnessChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WellnessCheck == null)
            {
                return Problem("Entity set 'FoodJournalWebAppContext.WellnessCheck'  is null.");
            }
            var wellnessCheck = await _context.WellnessCheck.FindAsync(id);
            if (wellnessCheck != null)
            {
                _context.WellnessCheck.Remove(wellnessCheck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WellnessCheckExists(int id)
        {
          return (_context.WellnessCheck?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
