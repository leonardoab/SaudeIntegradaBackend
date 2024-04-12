using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudeIntegrada.Domain.Domains;

namespace SaudeIntegrada.Repository.Mapping
{


    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Apelido).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Ativo);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(200);


            




        }
    }
}
