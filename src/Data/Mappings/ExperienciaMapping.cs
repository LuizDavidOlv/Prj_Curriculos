using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class ExperienciaMapping : IEntityTypeConfiguration<Experiencia>
    {
        public void Configure(EntityTypeBuilder<Experiencia> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Tecnologia)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.TempoExperiencia)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.DetalhesExperiencia)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.ToTable("Experiencias");
        }
    }
}
