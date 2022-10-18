using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDP.Data;
using CDP.Models;

namespace CDP.Controllers
{
    public class SementesController : Controller
    {
        private readonly CDPContext _context;

        public SementesController(CDPContext context)
        {
            _context = context;
        }

        // GET: Sementes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Semente.ToListAsync());
        }

        // GET: Sementes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Semente == null)
            {
                return NotFound();
            }

            var semente = await _context.Semente
                .FirstOrDefaultAsync(m => m.IdSemente == id);
            if (semente == null)
            {
                return NotFound();
            }

            return View(semente);
        }

        // GET: Sementes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sementes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSemente,Descricao")] Semente semente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semente);
        }

        // GET: Sementes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Semente == null)
            {
                return NotFound();
            }

            var semente = await _context.Semente.FindAsync(id);
            if (semente == null)
            {
                return NotFound();
            }
            return View(semente);
        }

        // POST: Sementes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSemente,Descricao")] Semente semente)
        {
            if (id != semente.IdSemente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SementeExists(semente.IdSemente))
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
            return View(semente);
        }

        // GET: Sementes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Semente == null)
            {
                return NotFound();
            }

            var semente = await _context.Semente
                .FirstOrDefaultAsync(m => m.IdSemente == id);
            if (semente == null)
            {
                return NotFound();
            }

            return View(semente);
        }

        // POST: Sementes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Semente == null)
            {
                return Problem("Entity set 'CDPContext.Semente'  is null.");
            }
            var semente = await _context.Semente.FindAsync(id);
            if (semente != null)
            {
                _context.Semente.Remove(semente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SementeExists(int id)
        {
          return _context.Semente.Any(e => e.IdSemente == id);
        }
    }
}
