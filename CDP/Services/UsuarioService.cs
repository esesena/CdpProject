using CDP.Data;
using CDP_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class UsuarioService
    {
        private readonly CDPContext _context;

        public UsuarioService(CDPContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuario.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task InsertAsync(Usuario obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

    }
}
