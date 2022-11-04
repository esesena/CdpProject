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
using System.Diagnostics;
using CDP.Services.Exceptions;

namespace CDP.Controllers
{
    public class PlantiosController : Controller
    {
        private readonly PlantioService _plantioService;
        private readonly TalhoesService _talhoesService;
        private readonly SafraService _safraService;

        public PlantiosController(PlantioService plantioService, TalhoesService talhoesService, SafraService safraService)
        {
            _plantioService = plantioService;
            _talhoesService = talhoesService;
            _safraService = safraService;
        }

        // GET: Plantios
        public async Task<IActionResult> Index()
        {
            var list = await _plantioService.FindAllAsync();
              return View(list);
        }

        // GET: Plantios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }

            var plantio = await _plantioService.FindByIdAsync(id.Value);
            if (plantio == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }
            
            return View(plantio);
        }

        // GET: Plantios/Create
        public async Task<IActionResult> Create()
        {
            var safra = await _safraService.FindAllAsync();
            var talhao = await _talhoesService.FindAllAsync();
            var viewModel = new PlantioFormViewModel { Safras = safra, Talhoes = talhao };

            return View(viewModel);
        }

        // POST: Plantios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlantio,DataPlantio,Chuva,TipoPlantio,Cultura,TempoPlantio,UmidadePlantio,IdSemente,QtdSementes,DistSementes,Adubacao")] Plantio plantio)
        {
            if (!ModelState.IsValid)
            {
                var safra = await _safraService.FindAllAsync();
                var talhao = await _talhoesService.FindAllAsync();
                var viewModel = new PlantioFormViewModel { Plantio = plantio, Safras = safra, Talhoes = talhao };
                return View(viewModel);
            }
            await _plantioService.InsertAsync(plantio);
            return RedirectToAction(nameof(Index));
        }

        // GET: Plantios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id plantio é nulo" });
            }
            var obj = await _plantioService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do plantio não localizado" });
            }

            List<Safra> safras = await _safraService.FindAllAsync();
            List<Talhoes> talhao = await _talhoesService.FindAllAsync();
            PlantioFormViewModel viewModel = new PlantioFormViewModel { Plantio = obj, Safras = safras, Talhoes = talhao };

            return View(viewModel);
        }

        // POST: Plantios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlantio,DataPlantio,Chuva,TipoPlantio,Cultura,TempoPlantio,UmidadePlantio,IdSemente,QtdSementes,DistSementes,Adubacao")] Plantio plantio)
        {
            if (!ModelState.IsValid)
            {
                var safra = await _safraService.FindAllAsync();
                var talhao = await _talhoesService.FindAllAsync();
                var viewModel = new PlantioFormViewModel { Plantio = plantio, Safras = safra, Talhoes = talhao };
                return View(viewModel);
            }

            if (id != plantio.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            try
            {
                await _plantioService.UpdateAsync(plantio);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Plantios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }
            var obj = await _plantioService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            return View(obj);
        }

        // POST: Plantios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _plantioService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
