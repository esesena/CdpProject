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
    public class SafrasController : Controller
    {
        private readonly SafraService _safraService;
        private readonly FuncionarioService _funcionarioService;

        public SafrasController(SafraService safraService, FuncionarioService funcionarioService)
        {
            _safraService = safraService;
            _funcionarioService = funcionarioService;
        }

        // GET: Safras
        public async Task<IActionResult> Index()
        {
            var list = await _safraService.FindAllAsync();
            return View(list);
        }

        // GET: Safras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }

            var usuario = await _safraService.FindByIdAsync(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            return View(usuario);
        }

        // GET: Safras/Create
        public async Task<IActionResult> Create()
        {
            var funcionario = await _funcionarioService.FindAllAsync();
            var viewModel = new SafraFormViewModel { Funcionarios = funcionario };
            return View(viewModel);
        }

        // POST: Safras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Safra safra)
        {
            if (!ModelState.IsValid)
            {
                var funcionarios = await _funcionarioService.FindAllAsync();
                var viewModel = new SafraFormViewModel { Safra = safra, Funcionarios = funcionarios};
                return View(viewModel);
            }
            await _safraService.InsertAsync(safra);
            return RedirectToAction(nameof(Index));
        }

        // GET: Safras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }
            var obj = await _safraService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            List<Funcionario> funcionarios = await _funcionarioService.FindAllAsync();
            SafraFormViewModel viewModel = new SafraFormViewModel { Safra = obj, Funcionarios = funcionarios };

            return View(viewModel);
        }

        // POST: Safras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Safra safra)
        {
            if (!ModelState.IsValid)
            {
                var funcionarios = await _funcionarioService.FindAllAsync();
                var viewModel = new SafraFormViewModel { Safra = safra, Funcionarios = funcionarios };

                return View(viewModel);
            }

            if (id != safra.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            try
            {
                await _safraService.UpdateAsync(safra);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Safras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }
            var obj = await _safraService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            return View(obj);
        }

        // POST: Safras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _safraService.RemoveAsync(id);
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
