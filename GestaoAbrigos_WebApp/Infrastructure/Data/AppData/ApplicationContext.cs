using GestaoAbrigos_WebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoAbrigos_WebApp.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<AbrigoEntity> Abrigos { get; set; }
        public DbSet<LocalizacaoEntity> Localizacoes { get; set; }
        public DbSet<OcupanteEntity> Ocupantes { get; set; }
        public DbSet<RecursoEntity> Recursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Abrigo → Localizacao (N:1)
            modelBuilder.Entity<AbrigoEntity>()
                .HasOne(a => a.Localizacao)
                .WithMany(l => l.Abrigos)
                .HasForeignKey(a => a.LocalizacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Abrigo → Ocupantes (1:N)
            modelBuilder.Entity<OcupanteEntity>()
                .HasOne(o => o.Abrigo)
                .WithMany(a => a.Ocupantes)
                .HasForeignKey(o => o.AbrigoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
