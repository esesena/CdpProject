using CDP.Data;
using CDP.Models;
using CDP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class SafraService
    {
        public readonly CDPContext _context;

        public SafraService(CDPContext context)
        {
            _context = context;
        }

        public async Task<List<Safra>> FindAllAsync()
        {
            return await _context.Safra.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task InsertAsync(Safra obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Safra> FindByIdAsync(int id)
        {
            return await _context.Safra.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Safra obj)
        {
            bool hasAny = await _context.Safra.AnyAsync(x => x.Id == obj.Id);
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
                throw new IntegrityException("Erro ao deletar cargo por existência de vínculo de funcionário");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Safra.FindAsync(id);
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
