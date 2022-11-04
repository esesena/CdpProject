using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CDP.Models;

namespace CDP.Data
{
    public class CDPContext : DbContext
    {
        public CDPContext (DbContextOptions<CDPContext> options)
            : base(options)
        {
        }

        public DbSet<CDP.Models.Cargo> Cargos { get; set; } = default!;

        public DbSet<CDP.Models.Usuario> Usuario { get; set; }

        public DbSet<CDP.Models.Funcionario> Funcionario { get; set; }

        public DbSet<CDP.Models.Plantio> Plantio { get; set; }

        public DbSet<CDP.Models.Safra> Safra { get; set; }

        public DbSet<CDP.Models.Semente> Semente { get; set; }

        public DbSet<CDP.Models.Fazenda> Fazenda { get; set; }

        public DbSet<CDP.Models.Talhoes> Talhoes { get; set; }

    }
}
