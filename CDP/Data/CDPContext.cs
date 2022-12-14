using CDP.Models;
using Microsoft.EntityFrameworkCore;

namespace CDP.Data
{
    public class CDPContext : DbContext
    {
        public CDPContext()
        {
        }

        public CDPContext (DbContextOptions<CDPContext> options) : base(options)
        {
        }

        public DbSet<Cargo> Cargos { get; set; } = default!;

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }

        public DbSet<Plantio> Plantio { get; set; }

        public DbSet<Semente> Semente { get; set; }

        public DbSet<Fazenda> Fazenda { get; set; }

        public DbSet<Talhoes> Talhoes { get; set; }

        public DbSet<Aviso> Aviso { get; set; }
        public DbSet<PlantioTalhoes> PlantioTalhoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantioTalhoes>()
                .HasKey(x => new { x.PlantioId, x.TalhoesId });
        }
    }
}
