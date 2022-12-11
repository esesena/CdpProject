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
    public class SementesController : Controller
    {

        private readonly SementeService _sementeService;

        public SementesController(SementeService sementeService)
        {
            _sementeService = sementeService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sementeService.FindAllAsync();
            return View(list);
        }

        // GET: Sementes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id cargo é nulo" });
            }

            var sementes = await _sementeService.FindByIdAsync(id.Value);
            if (sementes == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do cargo não localizado" });
            }

            return View(sementes);
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
        public async Task<IActionResult> Create(Semente semente)
        {
            if (ModelState.IsValid)
            {
                await _sementeService.InsertAsync(semente);
                return RedirectToAction(nameof(Index));
            }
            return View(semente);
        }

        // GET: Sementes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id semente é nulo" });
            }

            var semente = await _sementeService.FindByIdAsync(id.Value);
            if (semente == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do semente não localizado" });
            }
            return View(semente);
        }

        // POST: Sementes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Semente semente)
        {
            if (!ModelState.IsValid)
            {
                return View(semente);
            }

            if (id != semente.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do cargo não localizado" });
            }
            try
            {
                await _sementeService.UpdateAsync(semente);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Sementes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id semente é nulo" });
            }
            var obj = await _sementeService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do semente não localizado" });
            }

            return View(obj);
        }

        // POST: Sementes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _sementeService.RemoveAsync(id);
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
