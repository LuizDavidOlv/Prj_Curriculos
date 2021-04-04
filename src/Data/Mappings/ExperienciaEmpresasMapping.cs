using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class ExperienciaEmpresasMapping : IEntityTypeConfiguration<ExperienciaEmpresas>
    {
        public void Configure(EntityTypeBuilder<ExperienciaEmpresas> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(f => f.Empresa)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Cargo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.DataInicio)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(f => f.DataFim)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(f => f.DetalhesExperiencia)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Empresa)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.ToTable("ExperienciasEmpresas");


        }
    }
}
