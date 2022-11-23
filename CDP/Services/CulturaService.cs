using CDP.Data;
using CDP.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class CulturaService
    {
        public readonly CDPContext _context;

        public CulturaService(CDPContext context)
        {
            _context = context;
        }
    }
}
