using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CDP_Project.Models;

namespace CDP.Data
{
    public class CDPContext : DbContext
    {
        public CDPContext (DbContextOptions<CDPContext> options)
            : base(options)
        {
        }

        public DbSet<CDP_Project.Models.Cargo> Cargos { get; set; } = default!;

        public DbSet<CDP_Project.Models.Fazenda> Fazenda { get; set; }

        public DbSet<CDP_Project.Models.Usuario> Usuario { get; set; }
    }
}
