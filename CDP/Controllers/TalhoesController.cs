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
    public class TalhoesController : Controller
    {
        private readonly CDPContext _context;

        public TalhoesController(CDPContext context)
        {
            _context = context;
        }

        // GET: Talhoes
        public async Task<IActionResult> Index()
        {
            var cDPContext = _context.Talhoes.Include(t => t.Fazenda);
            return View(await cDPContext.ToListAsync());
        }

        // GET: Talhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Talhoes == null)
            {
                return NotFound();
            }

            var talhoes = await _context.Talhoes
                .Include(t => t.Fazenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talhoes == null)
            {
                return NotFound();
            }

            return View(talhoes);
        }

        // GET: Talhoes/Create
        public IActionResult Create()
        {
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "IdFazenda", "Localizacao");
            return View();
        }

        // POST: Talhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Localizacao,Area,TipoSolo,FazendaId")] Talhoes talhoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talhoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "IdFazenda", "Localizacao", talhoes.FazendaId);
            return View(talhoes);
        }

        // GET: Talhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Talhoes == null)
            {
                return NotFound();
            }

            var talhoes = await _context.Talhoes.FindAsync(id);
            if (talhoes == null)
            {
                return NotFound();
            }
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "IdFazenda", "Localizacao", talhoes.FazendaId);
            return View(talhoes);
        }

        // POST: Talhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Localizacao,Area,TipoSolo,FazendaId")] Talhoes talhoes)
        {
            if (id != talhoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talhoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalhoesExists(talhoes.Id))
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
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "IdFazenda", "Localizacao", talhoes.FazendaId);
            return View(talhoes);
        }

        // GET: Talhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Talhoes == null)
            {
                return NotFound();
            }

            var talhoes = await _context.Talhoes
                .Include(t => t.Fazenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talhoes == null)
            {
                return NotFound();
            }

            return View(talhoes);
        }

        // POST: Talhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Talhoes == null)
            {
                return Problem("Entity set 'CDPContext.Talhoes'  is null.");
            }
            var talhoes = await _context.Talhoes.FindAsync(id);
            if (talhoes != null)
            {
                _context.Talhoes.Remove(talhoes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalhoesExists(int id)
        {
          return _context.Talhoes.Any(e => e.Id == id);
        }
    }
}
