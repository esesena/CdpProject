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

        public DbSet<CDP_Project.Models.Funcionario> Funcionario { get; set; }

        public DbSet<CDP_Project.Models.Plantio> Plantio { get; set; }

        public DbSet<CDP_Project.Models.Safra> Safra { get; set; }

        public DbSet<CDP_Project.Models.Semente> Semente { get; set; }

        public DbSet<CDP_Project.Models.Talhoes> Talhoes { get; set; }
    }
}
