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
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _usuarioService.Usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _usuarioService.Usuario
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}

        // GET: Usuarios/Create
        public async Task<IActionResult> Create()
        {
            var cargo = await _cargosService.FindAllAsync();
            var viewModel = new UsuarioFormViewmodel { Cargos = cargo };

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
                var viewModel = new UsuarioFormViewmodel { Usuario = usuario, Cargos = cargos};
                return View(viewModel);
            }
            await _usuarioService.InsertAsync(usuario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _usuarioService.Usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _usuarioService.Usuario.FindAsync(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(usuario);
        //}

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,Admin,Ativo,Telefone,Celular,IdCargo")] Usuario usuario)
    //    {
    //        if (id != usuario.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _usuarioService.Update(usuario);
    //                await _usuarioService.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!UsuarioExists(usuario.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(usuario);
    //    }

    //    // GET: Usuarios/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null || _usuarioService.Usuario == null)
    //        {
    //            return NotFound();
    //        }

    //        var usuario = await _usuarioService.Usuario
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (usuario == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(usuario);
    //    }

    //    // POST: Usuarios/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        if (_usuarioService.Usuario == null)
    //        {
    //            return Problem("Entity set 'CDPContext.Usuario'  is null.");
    //        }
    //        var usuario = await _usuarioService.Usuario.FindAsync(id);
    //        if (usuario != null)
    //        {
    //            _usuarioService.Usuario.Remove(usuario);
    //        }
            
    //        await _usuarioService.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool UsuarioExists(int id)
    //    {
    //      return _usuarioService.Usuario.Any(e => e.Id == id);
    //    }
    }
}
