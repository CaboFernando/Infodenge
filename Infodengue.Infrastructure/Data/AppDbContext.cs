using Infodengue.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infodengue.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Solicitante
            modelBuilder.Entity<Solicitante>()
                .HasIndex(s => s.Cpf)
                .IsUnique();

            modelBuilder.Entity<Solicitante>()
                .Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Solicitante>()
                .Property(s => s.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            // Relatorio
            modelBuilder.Entity<Relatorio>()
                .Property(r => r.Arbovirose)
                .IsRequired();

            modelBuilder.Entity<Relatorio>()
                .HasOne(r => r.Solicitante)
                .WithMany(s => s.Relatorios)
                .HasForeignKey(r => r.SolicitanteId);
        }
    }
}
