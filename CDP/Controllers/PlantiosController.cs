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
    public class PlantiosController : Controller
    {
        private readonly CDPContext _context;

        public PlantiosController(CDPContext context)
        {
            _context = context;
        }

        // GET: Plantios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Plantio.ToListAsync());
        }

        // GET: Plantios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plantio == null)
            {
                return NotFound();
            }

            var plantio = await _context.Plantio
                .FirstOrDefaultAsync(m => m.IdPlantio == id);
            if (plantio == null)
            {
                return NotFound();
            }

            return View(plantio);
        }

        // GET: Plantios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plantios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlantio,DataPlantio,Chuva,TipoPlantio,Cultura,TempoPlantio,UmidadePlantio,IdSemente,QtdSementes,DistSementes,Adubacao")] Plantio plantio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantio);
        }

        // GET: Plantios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plantio == null)
            {
                return NotFound();
            }

            var plantio = await _context.Plantio.FindAsync(id);
            if (plantio == null)
            {
                return NotFound();
            }
            return View(plantio);
        }

        // POST: Plantios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlantio,DataPlantio,Chuva,TipoPlantio,Cultura,TempoPlantio,UmidadePlantio,IdSemente,QtdSementes,DistSementes,Adubacao")] Plantio plantio)
        {
            if (id != plantio.IdPlantio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantioExists(plantio.IdPlantio))
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
            return View(plantio);
        }

        // GET: Plantios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plantio == null)
            {
                return NotFound();
            }

            var plantio = await _context.Plantio
                .FirstOrDefaultAsync(m => m.IdPlantio == id);
            if (plantio == null)
            {
                return NotFound();
            }

            return View(plantio);
        }

        // POST: Plantios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plantio == null)
            {
                return Problem("Entity set 'CDPContext.Plantio'  is null.");
            }
            var plantio = await _context.Plantio.FindAsync(id);
            if (plantio != null)
            {
                _context.Plantio.Remove(plantio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantioExists(int id)
        {
          return _context.Plantio.Any(e => e.IdPlantio == id);
        }
    }
}
