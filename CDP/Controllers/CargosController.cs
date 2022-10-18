using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDP.Data;
using CDP.Models;
using CDP.Models.ViewModels;
using System.Diagnostics;
using CDP.Services;
using CDP.Services.Exceptions;

namespace CDP.Controllers
{
    public class CargosController : Controller
    {
        private readonly CargoService _cargosService;

        public CargosController(CargoService cargosService)
        {
            _cargosService = cargosService;
        }

        // GET: Cargos
        public async Task<IActionResult> Index()
        {
            var list = await _cargosService.FindAllAsync();
            return View(list);
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id cargo é nulo" });
            }

            var cargos = await _cargosService.FindByIdAsync(id.Value);
            if (cargos == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do cargo não localizado" });
            }

            return View(cargos);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cargo cargos)
        {
            if (ModelState.IsValid)
            {
                await _cargosService.InsertAsync(cargos);
                return RedirectToAction(nameof(Index));
            }
            return View(cargos);
        }

        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id cargo é nulo" });
            }

            var cargos = await _cargosService.FindByIdAsync(id.Value);
            if (cargos == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do cargo não localizado" });
            }
            return View(cargos);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cargo cargo)
        {
            if (!ModelState.IsValid)
            {
                return View(cargo);
            }

            if (id != cargo.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do cargo não localizado" });
            }
            try
            {
                await _cargosService.UpdateAsync(cargo);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id cargo é nulo" });
            }
            var obj = await _cargosService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do cargo não localizado" });
            }

            return View(obj);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _cargosService.RemoveAsync(id);
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
