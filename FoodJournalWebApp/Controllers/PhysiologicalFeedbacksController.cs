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
    public class PhysiologicalFeedbacksController : Controller
    {
        private readonly FoodJournalWebAppContext _context;

        public PhysiologicalFeedbacksController(FoodJournalWebAppContext context)
        {
            _context = context;
        }

        // GET: PhysiologicalFeedbacks
        public async Task<IActionResult> Index()
        {
              return _context.PhysiologicalFeedback != null ? 
                          View(await _context.PhysiologicalFeedback.ToListAsync()) :
                          Problem("Entity set 'FoodJournalWebAppContext.PhysiologicalFeedback'  is null.");
        }

        // GET: PhysiologicalFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhysiologicalFeedback == null)
            {
                return NotFound();
            }

            var physiologicalFeedback = await _context.PhysiologicalFeedback
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physiologicalFeedback == null)
            {
                return NotFound();
            }

            return View(physiologicalFeedback);
        }

        // GET: PhysiologicalFeedbacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhysiologicalFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sentiment,Descriptor")] PhysiologicalFeedback physiologicalFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(physiologicalFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(physiologicalFeedback);
        }

        // GET: PhysiologicalFeedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhysiologicalFeedback == null)
            {
                return NotFound();
            }

            var physiologicalFeedback = await _context.PhysiologicalFeedback.FindAsync(id);
            if (physiologicalFeedback == null)
            {
                return NotFound();
            }
            return View(physiologicalFeedback);
        }

        // POST: PhysiologicalFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sentiment,Descriptor")] PhysiologicalFeedback physiologicalFeedback)
        {
            if (id != physiologicalFeedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(physiologicalFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysiologicalFeedbackExists(physiologicalFeedback.Id))
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
            return View(physiologicalFeedback);
        }

        // GET: PhysiologicalFeedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhysiologicalFeedback == null)
            {
                return NotFound();
            }

            var physiologicalFeedback = await _context.PhysiologicalFeedback
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physiologicalFeedback == null)
            {
                return NotFound();
            }

            return View(physiologicalFeedback);
        }

        // POST: PhysiologicalFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhysiologicalFeedback == null)
            {
                return Problem("Entity set 'FoodJournalWebAppContext.PhysiologicalFeedback'  is null.");
            }
            var physiologicalFeedback = await _context.PhysiologicalFeedback.FindAsync(id);
            if (physiologicalFeedback != null)
            {
                _context.PhysiologicalFeedback.Remove(physiologicalFeedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhysiologicalFeedbackExists(int id)
        {
          return (_context.PhysiologicalFeedback?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
