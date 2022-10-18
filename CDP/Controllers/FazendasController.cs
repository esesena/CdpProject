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
    public class FazendasController : Controller
    {
        private readonly CDPContext _context;

        public FazendasController(CDPContext context)
        {
            _context = context;
        }

        // GET: Fazendas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Fazenda.ToListAsync());
        }

        // GET: Fazendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fazenda == null)
            {
                return NotFound();
            }

            var fazenda = await _context.Fazenda
                .FirstOrDefaultAsync(m => m.IdFazenda == id);
            if (fazenda == null)
            {
                return NotFound();
            }

            return View(fazenda);
        }

        // GET: Fazendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fazendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFazenda,Nome,Localizacao,Area")] Fazenda fazenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fazenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fazenda);
        }

        // GET: Fazendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fazenda == null)
            {
                return NotFound();
            }

            var fazenda = await _context.Fazenda.FindAsync(id);
            if (fazenda == null)
            {
                return NotFound();
            }
            return View(fazenda);
        }

        // POST: Fazendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFazenda,Nome,Localizacao,Area")] Fazenda fazenda)
        {
            if (id != fazenda.IdFazenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fazenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FazendaExists(fazenda.IdFazenda))
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
            return View(fazenda);
        }

        // GET: Fazendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fazenda == null)
            {
                return NotFound();
            }

            var fazenda = await _context.Fazenda
                .FirstOrDefaultAsync(m => m.IdFazenda == id);
            if (fazenda == null)
            {
                return NotFound();
            }

            return View(fazenda);
        }

        // POST: Fazendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fazenda == null)
            {
                return Problem("Entity set 'CDPContext.Fazenda'  is null.");
            }
            var fazenda = await _context.Fazenda.FindAsync(id);
            if (fazenda != null)
            {
                _context.Fazenda.Remove(fazenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FazendaExists(int id)
        {
          return _context.Fazenda.Any(e => e.IdFazenda == id);
        }
    }
}
