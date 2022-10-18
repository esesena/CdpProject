using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDP.Data;
using CDP_Project.Models;

namespace CDP.Controllers
{
    public class SafrasController : Controller
    {
        private readonly CDPContext _context;

        public SafrasController(CDPContext context)
        {
            _context = context;
        }

        // GET: Safras
        public async Task<IActionResult> Index()
        {
              return View(await _context.Safra.ToListAsync());
        }

        // GET: Safras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Safra == null)
            {
                return NotFound();
            }

            var safra = await _context.Safra
                .FirstOrDefaultAsync(m => m.IdSafra == id);
            if (safra == null)
            {
                return NotFound();
            }

            return View(safra);
        }

        // GET: Safras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Safras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSafra,Nome,IdTalhao")] Safra safra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(safra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(safra);
        }

        // GET: Safras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Safra == null)
            {
                return NotFound();
            }

            var safra = await _context.Safra.FindAsync(id);
            if (safra == null)
            {
                return NotFound();
            }
            return View(safra);
        }

        // POST: Safras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSafra,Nome,IdTalhao")] Safra safra)
        {
            if (id != safra.IdSafra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(safra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SafraExists(safra.IdSafra))
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
            return View(safra);
        }

        // GET: Safras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Safra == null)
            {
                return NotFound();
            }

            var safra = await _context.Safra
                .FirstOrDefaultAsync(m => m.IdSafra == id);
            if (safra == null)
            {
                return NotFound();
            }

            return View(safra);
        }

        // POST: Safras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Safra == null)
            {
                return Problem("Entity set 'CDPContext.Safra'  is null.");
            }
            var safra = await _context.Safra.FindAsync(id);
            if (safra != null)
            {
                _context.Safra.Remove(safra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SafraExists(int id)
        {
          return _context.Safra.Any(e => e.IdSafra == id);
        }
    }
}
