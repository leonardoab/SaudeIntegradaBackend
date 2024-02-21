using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaudeIntegrada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Repository
{

    public class SaudeIntegradaContext : DbContext
    {
        public DbSet<AvaliacaoFicha> Usuarios { get; set; }
        public DbSet<ExercicioBase> Assinaturas { get; set; }
        public DbSet<ExercicioFicha> ExercicioFichas { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }


        public SaudeIntegradaContext(DbContextOptions<SaudeIntegradaContext> options) : base(options)
        {

        }


        //Escrever protected internal e vai aparecer OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaudeIntegradaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
