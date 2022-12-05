using CDP.Data;
using CDP.Models;
using CDP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class SementeService
    {
        public readonly CDPContext _context;

        public SementeService(CDPContext context)
        {
            _context = context;
        }
        public async Task<List<Semente>> FindAllAsync()
        {
            return await _context.Semente.OrderBy(x => x.Descricao).ToListAsync();
        }

        public async Task InsertAsync(Semente obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Semente> FindByIdAsync(int id)
        {
            return await _context.Semente.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Semente obj)
        {
            bool hasAny = await _context.Semente.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id da Semente não encontrado");
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
                var obj = await _context.Semente.FindAsync(id);
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
