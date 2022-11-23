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

        public async Task<List<Aviso>> FindAllAsync()
        {
            return await _context.Aviso.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
