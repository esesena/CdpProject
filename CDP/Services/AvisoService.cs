using CDP.Data;
using CDP.Models;
using CDP.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class AvisoService
    {
        private readonly CDPContext _context;

        public AvisoService (CDPContext context)
        {
            _context = context;
        }

        public async Task<List<Aviso>> FindLowPriority()
        {
            return await _context.Aviso.OrderBy(x => x.Name).Where(x => x.Prioridade == 0).ToListAsync();
        }

        public async Task<List<Aviso>> FindByPriority(int priority)
        {
            return await _context.Aviso.OrderBy(x => x.Name).Where(x => (int)x.Prioridade == priority).ToListAsync();
        }

        public async Task<List<Aviso>> FindAllLow()
        {
            return await _context.Aviso.OrderBy(x => x.Name).Where(x => x.Prioridade == 0).ToListAsync();
        }

    }
}
