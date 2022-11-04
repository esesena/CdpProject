using CDP.Data;
using CDP.Models;
using CDP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class FazendaService
    {
        private readonly CDPContext _context;

        public FazendaService(CDPContext context)
        {
            _context = context;
        }

        public async Task<List<Fazenda>> FindAllAsync()
        {
            return await _context.Fazenda.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task InsertAsync(Fazenda obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Fazenda> FindByIdAsync(int id)
        {
            return await _context.Fazenda.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Fazenda obj)
        {
            bool hasAny = await _context.Fazenda.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id da Fazenda não encontrado");
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
                var obj = await _context.Fazenda.FindAsync(id);
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
