using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldRecipes.Models;

namespace WorldRecipes.Controllers
{
    public class PatmentsController : Controller
    {
        private readonly ModelContext _context;

        public PatmentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Patments
        public async Task<IActionResult> Index()
        {
              return _context.Patments != null ? 
                          View(await _context.Patments.ToListAsync()) :
                          Problem("Entity set 'ModelContext.Patments'  is null.");
        }

        // GET: Patments/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Patments == null)
            {
                return NotFound();
            }

            var patment = await _context.Patments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patment == null)
            {
                return NotFound();
            }

            return View(patment);
        }

        // GET: Patments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardNumber,Ccv,ExDate")] Patment patment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patment);
        }

        // GET: Patments/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Patments == null)
            {
                return NotFound();
            }

            var patment = await _context.Patments.FindAsync(id);
            if (patment == null)
            {
                return NotFound();
            }
            return View(patment);
        }

        // POST: Patments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,CardNumber,Ccv,ExDate")] Patment patment)
        {
            if (id != patment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatmentExists(patment.Id))
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
            return View(patment);
        }

        // GET: Patments/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Patments == null)
            {
                return NotFound();
            }

            var patment = await _context.Patments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patment == null)
            {
                return NotFound();
            }

            return View(patment);
        }

        // POST: Patments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Patments == null)
            {
                return Problem("Entity set 'ModelContext.Patments'  is null.");
            }
            var patment = await _context.Patments.FindAsync(id);
            if (patment != null)
            {
                _context.Patments.Remove(patment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatmentExists(decimal id)
        {
          return (_context.Patments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
