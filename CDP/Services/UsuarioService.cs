using CDP.Data;
using CDP.Services.Exceptions;
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

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuario.Include(obj => obj.Cargos).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Usuario obj)
        {
            bool hasAny = await _context.Usuario.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id do usuário não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new IntegrityException("Erro ao deletar usuário por existência de vínculo de negócio");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Usuario.FindAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
                throw;
            }
        }
    }
}
