using CDP.Data;
using CDP.Models;
using CDP.Models.ViewModels;
using CDP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class PlantioService
    {
        private readonly CDPContext _context;

        public PlantioService (CDPContext context)
        {
            _context = context;
        }

        public async Task<List<Plantio>> FindAllAsync()
        {
            return await _context.Plantio.OrderByDescending(x => x.Safra).ToListAsync();
        }

        public async Task<List<Plantio>> FindAllWithSementesAsync()
        {
            return await _context.Plantio.OrderByDescending(x => x.Safra).Include(s => s.Sementes).ToListAsync();
        }

        public async Task InsertAsync(Plantio obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Plantio> FindByIdAsync(int id)
        {
            return await _context.Plantio.Include(obj => obj.Safra).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync(Plantio obj)
        {
            bool hasAny = await _context.Plantio.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id da safra não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new IntegrityException("Erro ao deletar safra por existência de vínculo de negócio");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Plantio.FindAsync(id);
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
