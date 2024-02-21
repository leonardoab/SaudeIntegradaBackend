using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain
{
    public class AvaliacaoFichaMapping : IEntityTypeConfiguration<AvaliacaoFicha>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoFicha> builder)
        {
            builder.ToTable("AvaliacaoFicha");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.VelocidadeExecucao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Descanso).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Duracao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataTesteCarga).IsRequired();
            builder.Property(x => x.DataProximoTesteCarga).IsRequired();
            builder.Property(x => x.Observacoes).IsRequired().HasMaxLength(200);

            builder.HasMany(x => x.Fichas).WithOne().OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}