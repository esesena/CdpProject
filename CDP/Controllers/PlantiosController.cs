using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDP.Data;
using CDP.Models;
using CDP.Services;
using CDP.Models.ViewModels;

namespace CDP.Controllers
{
    public class PlantiosController : Controller
    {

        private readonly CDPContext _context;
        private readonly PlantioTalhoesService _plantioTalhoesService;
        private readonly PlantioService _plantioService;
        private readonly SementeService _sementeService;
        private readonly TalhoesService _talhoesService;

        public PlantiosController(CDPContext context, PlantioTalhoesService plantioTalhoesService, PlantioService plantioService, SementeService sementeService, TalhoesService talhoesService)
        {
            _context = context;
            _plantioTalhoesService = plantioTalhoesService;
            _plantioService = plantioService;
            _sementeService = sementeService;
            _talhoesService = talhoesService;
        }

        // GET: Plantios
        public async Task<IActionResult> Index()
        {
            var cDPContext = _context.Plantio.Include(p => p.Sementes);
            return View(await cDPContext.ToListAsync());
        }

        // GET: Plantios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plantio == null)
            {
                return NotFound();
            }


            var Talhoes = from p in _context.Talhoes
                                   select new
                                   {
                                       p.Id,
                                       p.Nome,
                                       Checked = ((from ce in _context.PlantioTalhoes
                                                   where (ce.PlantioId == id) & (ce.TalhoesId == p.Id)
                                                   select ce).Count() > 0)
                                   };
            ViewBag.talhoes = Talhoes;

            var listaTalhoes = new List<PlantioTalhoesViewModel>();


            foreach (var item in Talhoes)
            {
                listaTalhoes.Add(new PlantioTalhoesViewModel { Id = item.Id, Name = item.Nome, Checked = item.Checked });
            }
            ViewBag.teste = listaTalhoes.Where(t => t.Checked == true).ToList();

            var plantio = await _context.Plantio
                .Include(p => p.Sementes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantio == null)
            {
                return NotFound();
            }

            return View(plantio);
        }

        // GET: Plantios/Create
        public IActionResult Create()
        {
            ViewData["SementeId"] = new SelectList(_context.Semente, "Id", "Descricao");
            ViewBag.Talhoes = _context.Talhoes.ToList();
            return View();
        }

        // POST: Plantios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataPlantio,Cultura,Safra,Chuva,TipoPlantio,TempoPlantio,UmidadePlantio,SementeId,QtdSementes,DistSementes,Adubacao")] Plantio plantio, int[] TalhoesId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantio);
                await _context.SaveChangesAsync();
                int plantioId = plantio.Id;
                await _plantioTalhoesService.InsertAsync(plantioId, TalhoesId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SementeId"] = new SelectList(_context.Semente, "Id", "Descricao", plantio.SementeId);
            var talhoes = await _talhoesService.FindAllAsync();
            ViewBag.Talhoes = talhoes.ToList();
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
            ViewData["SementeId"] = new SelectList(_context.Semente, "Id", "Descricao", plantio.SementeId);
            return View(plantio);
        }

        // POST: Plantios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataPlantio,Cultura,Safra,Chuva,TipoPlantio,TempoPlantio,UmidadePlantio,SementeId,QtdSementes,DistSementes,Adubacao")] Plantio plantio)
        {
            if (id != plantio.Id)
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
                    if (!PlantioExists(plantio.Id))
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
            ViewData["SementeId"] = new SelectList(_context.Semente, "Id", "Descricao", plantio.SementeId);
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
                .Include(p => p.Sementes)
                .FirstOrDefaultAsync(m => m.Id == id);
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
          return _context.Plantio.Any(e => e.Id == id);
        }
    }
}
