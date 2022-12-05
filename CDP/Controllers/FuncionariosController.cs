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
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly CargoService _cargosService;

        public FuncionariosController(FuncionarioService funcionarioService, CargoService cargosService)
        {
            _funcionarioService = funcionarioService;
            _cargosService = cargosService;
        }

            // GET: Funcionarios
            public async Task<IActionResult> Index()
        {
            var list = await _funcionarioService.FindAllAsync();
            return View(list);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }

            var funcionario = await _funcionarioService.FindByIdAsync(id.Value);
            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public async Task<IActionResult> Create()
        {
            var cargo = await _cargosService.FindAllAsync();
            var viewModel = new FuncionarioFormViewModel { Cargos = cargo };

            return View(viewModel);
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                var cargos = await _cargosService.FindAllAsync();
                var viewModel = new FuncionarioFormViewModel { Funcionario = funcionario, Cargos = cargos };
                return View(viewModel);
            }
            await _funcionarioService.InsertAsync(funcionario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }
            var obj = await _funcionarioService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            List<Cargo> cargos = await _cargosService.FindAllAsync();
            FuncionarioFormViewModel viewModel = new FuncionarioFormViewModel { Funcionario = obj, Cargos = cargos };

            return View(viewModel);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                var cargos = await _cargosService.FindAllAsync();
                var viewModel = new FuncionarioFormViewModel { Funcionario = funcionario, Cargos = cargos };

                return View(viewModel);
            }

            if (id != funcionario.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            try
            {
                await _funcionarioService.UpdateAsync(funcionario);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }
            var obj = await _funcionarioService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            return View(obj);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _funcionarioService.RemoveAsync(id);
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
