using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class CurriculoMapping : IEntityTypeConfiguration<Curriculo>
    {
        public void Configure(EntityTypeBuilder<Curriculo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(c => c.ExperienciaTotal)
                .IsRequired()
                .HasColumnType("int");

            builder.HasMany(f => f.Formacao)
                .WithOne(e => e.Curriculo)
                .HasForeignKey(p => p.CurriculoId);

            builder.HasMany(f => f.Experiencias)
                .WithOne(e => e.Curriculo)
                .HasForeignKey(p => p.CurriculoId);

            builder.HasMany(f => f.ExperienciasEmpresas)
                .WithOne(e => e.Curriculo)
                .HasForeignKey(p => p.CurriculoId);

            builder.ToTable("Curriculos");

        }
    }
}
