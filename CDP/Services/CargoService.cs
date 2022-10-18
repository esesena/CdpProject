using CDP.Data;
using CDP.Models;
using CDP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class CargoService
    {
        public readonly CDPContext _context;

        public CargoService(CDPContext context)
        {
            _context = context;
        }

        public async Task<List<Cargo>> FindAllAsync()
        {
            return await _context.Cargos.OrderBy(x => x.Descricao).ToListAsync();
        }

        public async Task InsertAsync(Cargo obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Cargo> FindByIdAsync(int id)
        {
            return await _context.Cargos.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Cargo obj)
        {
            bool hasAny = await _context.Cargos.AnyAsync(x => x.Id == obj.Id);
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
                var obj = await _context.Cargos.FindAsync(id);
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
