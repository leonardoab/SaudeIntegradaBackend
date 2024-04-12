using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudeIntegrada.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
           
            builder.Property(x => x.Sexo).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataNascimento).IsRequired();

            builder.HasMany(p => p.AvaliacaoFichas)
                   .WithOne(a => a.Pessoa);   // Definindo a entidade pai (Pessoa) //builder.HasMany(x => x.AvaliacaoFichas).WithOne().OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Conta)
                   .WithOne()
                   .HasForeignKey<Pessoa>(x => x.ContaId);  // Especificando a chave estrangeira

        }
    }
}