using Microsoft.EntityFrameworkCore;
using boletos_banco.Data.Models;

namespace boletos_banco.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Banco> Bancos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Boleto>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Banco>()
                .HasKey(b => b.Id);
        }
    }
}
