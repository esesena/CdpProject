using CDP.Data;
using CDP_Project.Models;
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
    }
}
