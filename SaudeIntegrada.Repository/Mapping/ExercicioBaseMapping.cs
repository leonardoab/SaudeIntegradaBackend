using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaudeIntegrada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Repository.Mapping
{
    public class ExercicioBaseMapping : IEntityTypeConfiguration<ExercicioBase>
    {
        public void Configure(EntityTypeBuilder<ExercicioBase> builder)
        {
            builder.ToTable("ExercicioBase");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        }
    }
}