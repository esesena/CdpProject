using CDP.Data;
using CDP.Models;
using CDP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class TalhoesService
    {
        public readonly CDPContext _context;

        public TalhoesService(CDPContext context)
        {
            _context = context;
        }

        public async Task<List<Talhoes>> FindAllAsync()
        {
            return await _context.Talhoes.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task InsertAsync(Talhoes obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Talhoes> FindByIdAsync(int id)
        {
            return await _context.Talhoes.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Talhoes obj)
        {
            bool hasAny = await _context.Talhoes.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id do talhão não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new IntegrityException("Erro ao deletar talhão por existência de vínculo de fazenda");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Talhoes.FindAsync(id);
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
