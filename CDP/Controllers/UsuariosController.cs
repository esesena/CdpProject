using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDP.Data;
using CDP_Project.Models;
using CDP.Services;
using CDP.Models.ViewModels;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using CDP.Services.Exceptions;

namespace CDP.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly CargoService _cargosService;

        public UsuariosController(UsuarioService usuarioService, CargoService cargosService)
        {
            _usuarioService = usuarioService;
            _cargosService = cargosService;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var list = await _usuarioService.FindAllAsync();
            return View(list);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not privided" });
            }

            var usuario = await _usuarioService.FindByIdAsync(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public async Task<IActionResult> Create()
        {
            var cargo = await _cargosService.FindAllAsync();
            var viewModel = new UsuarioFormViewModel { Cargos = cargo };

            return View(viewModel);
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                var cargos = await _cargosService.FindAllAsync();
                var viewModel = new UsuarioFormViewModel { Usuario = usuario, Cargos = cargos};
                return View(viewModel);
            }
            await _usuarioService.InsertAsync(usuario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }
            var obj = await _usuarioService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado"});
            }

            List<Cargo> cargos = await _cargosService.FindAllAsync();
            UsuarioFormViewModel viewModel = new UsuarioFormViewModel { Usuario = obj, Cargos = cargos };

            return View(viewModel);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                var cargos = await _cargosService.FindAllAsync();
                var viewModel = new UsuarioFormViewModel { Usuario = usuario, Cargos = cargos };

                return View(viewModel);
            }

            if (id != usuario.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            try
            {
                await _usuarioService.UpdateAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id usuário é nulo" });
            }
            var obj = await _usuarioService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do usuário não localizado" });
            }

            return View(obj);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _usuarioService.RemoveAsync(id);
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
